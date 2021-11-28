using itu.DAL.Entities;
using itu.DAL.Entities.Tasks;
using itu.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.DAL
{
    public class ItuDbContext : DbContext
    {
        public ItuDbContext(DbContextOptions<ItuDbContext> options) : base(options) { }

        public DbSet<WorkflowEntity> Workflows { get; set; }
        public DbSet<NoteEntity> Notes { get; set; }
        public DbSet<AgendaEntity> Agendas { get; set; }
        public DbSet<AgendaRoleEntity> AgendaRoles { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ModelWorkflowEntity> ModelWorkflows { get; set; }
        public DbSet<ModelWorkflowTaskEntity> ModelWorkflowTasks { get; set; }
        public DbSet<ModelTaskEntity> ModelTasks { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<FileEntity> Files { get; set; }
        public DbSet<FileDataEntity> FileData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<TaskEntity>().HasOne(x => x.User).WithMany(x => x.Tasks).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<TaskEntity>().HasOne(x => x.Workflow).WithMany(x => x.Tasks).HasForeignKey(x => x.WorkflowId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ContractEntity>().ToTable("Contracts");
            modelBuilder.Entity<AcceptationEntity>().ToTable("Acceptations");
            modelBuilder.Entity<ArchivationEntity>().ToTable("Archivations");
            modelBuilder.Entity<AssessmentEntity>().ToTable("Assessments");
            modelBuilder.Entity<AssignmentEntity>().ToTable("Assignments");
            modelBuilder.Entity<EstimateEntity>().ToTable("Estimates");
            modelBuilder.Entity<PublishEntity>().ToTable("Publishes");

            modelBuilder.Entity<ModelTaskEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<ModelTaskEntity>().HasMany(x => x.WorkflowTasks).WithOne(x => x.ModelTask).HasForeignKey(x => x.ModelTaskId);

            modelBuilder.Entity<NoteEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<NoteEntity>().HasOne(x => x.Workflow).WithMany(x => x.Notes).HasForeignKey(x => x.WorkflowId);

            modelBuilder.Entity<WorkflowEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<WorkflowEntity>().HasOne(x => x.Agenda).WithMany(x => x.Workflows).HasForeignKey(x => x.AgendaId);
            modelBuilder.Entity<WorkflowEntity>().HasOne(x => x.ModelWorkflow).WithMany(x => x.Worflows).HasForeignKey(x => x.ModelWorkflowId);

            modelBuilder.Entity<ModelWorkflowTaskEntity>().HasKey(x => new { x.ModelTaskId, x.ModelWorkflowId });

            modelBuilder.Entity<AgendaModelEntity>().HasKey(x => new { x.ModelId, x.AgendaId });

            modelBuilder.Entity<ModelWorkflowEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<ModelWorkflowEntity>().HasMany(x => x.AgendaModels).WithOne(x => x.Model).HasForeignKey(x => x.ModelId);
            modelBuilder.Entity<ModelWorkflowEntity>().HasMany(x => x.WorkflowTasks).WithOne(x => x.ModelWorkflow).HasForeignKey(x => x.ModelWorkflowId);

            modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<UserEntity>().HasMany(x => x.AgendaRoles).WithOne(x => x.User).HasForeignKey(x => x.UserId);

            modelBuilder.Entity<FileEntity>().HasOne(x => x.Workflow).WithMany(x => x.Files).HasForeignKey(x => x.WorkflowId);
            modelBuilder.Entity<FileEntity>().HasOne(x => x.FileData).WithOne(x => x.File).HasForeignKey<FileEntity>(x => x.FileDataId);

            modelBuilder.Entity<AgendaEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<AgendaEntity>().HasMany(x => x.AgendaModels).WithOne(x => x.Agenda).HasForeignKey(x => x.AgendaId);
            modelBuilder.Entity<AgendaEntity>().HasOne(x => x.Administrator).WithMany(x => x.Agendas).HasForeignKey(x => x.AdministratorId);

            modelBuilder.Entity<AgendaRoleEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<AgendaRoleEntity>().HasOne(x => x.Agenda).WithMany(x => x.AgendaRoles).HasForeignKey(x => x.AgendaId);
            modelBuilder.Entity<AgendaRoleEntity>().HasOne(x => x.User).WithMany(x => x.AgendaRoles).HasForeignKey(x => x.UserId);

            modelBuilder.Entity<FileDataEntity>().HasKey(x => x.Id);

            modelBuilder.SeedModelTasks();
            modelBuilder.SeedModelWorkflows();
            modelBuilder.SeedModelWorkflowTasks();
            modelBuilder.SeedUsers();
            modelBuilder.SeedAgendas();
            modelBuilder.SeedTasks();
            modelBuilder.SeedWorkflows();
            modelBuilder.SeedFiles();
            modelBuilder.SeedFileData();
            modelBuilder.SeedAgendaRoles();
            modelBuilder.SeedAgendaModels();
        }
    }
}
