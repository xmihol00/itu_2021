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

            modelBuilder.Entity<ContractEntity>().ToTable("Contracts");
            modelBuilder.Entity<AcceptationEntity>().ToTable("Acceptations");
            modelBuilder.Entity<ArchivationEntity>().ToTable("Archivations");
            modelBuilder.Entity<AssessmentEntity>().ToTable("Assessments");
            modelBuilder.Entity<AssignmentEntity>().ToTable("Assignments");
            modelBuilder.Entity<EstimateEntity>().ToTable("Estimates");
            modelBuilder.Entity<PublishEntity>().ToTable("Publishes");
        }
    }
}
