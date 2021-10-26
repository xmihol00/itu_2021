using itu.DAL.Entities;
using itu.DAL.Entities.Tasks;
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

        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<TaskEntity>().HasOne(x => x.Previous).WithOne(x => x.Next).HasForeignKey<TaskEntity>(x => x.PreviousId);
            modelBuilder.Entity<TaskEntity>().HasOne(x => x.Next).WithOne(x => x.Previous).HasForeignKey<TaskEntity>(x => x.NextId);
            modelBuilder.Entity<TaskEntity>().HasOne(x => x.User).WithMany(x => x.Tasks).HasForeignKey(x => x.UserId);

            modelBuilder.Entity<ContractEntity>().ToTable("Contracts");
            modelBuilder.Entity<AcceptationEntity>().ToTable("Acceptations");
            modelBuilder.Entity<ArchivationEntity>().ToTable("Archivations");
            modelBuilder.Entity<AssessmentEntity>().ToTable("Assessments");
            modelBuilder.Entity<AssignmentEntity>().ToTable("Assignments");
            modelBuilder.Entity<EstimateEntity>().ToTable("Estimates");
            modelBuilder.Entity<PublishEntity>().ToTable("Publishes");

            modelBuilder.Entity<UserAgendaEntity>().HasKey(x => new { x.AgendaId, x.UserId, x.Role });
        }
    }
}
