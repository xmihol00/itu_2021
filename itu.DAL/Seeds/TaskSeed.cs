using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.DAL.Entities;
using itu.DAL.Entities.Tasks;
using Microsoft.EntityFrameworkCore;

namespace itu.DAL.Seeds
{
    public static class TaskSeed
    {
        private static readonly List<TaskEntity> _task = new List<TaskEntity>()
        {

        };

        public static void SeedTasks(this ModelBuilder modelBuilder)
        {
            foreach (TaskEntity task in _task)
            {
                if (task.GetType() == typeof(TaskEntity))
                {
                    modelBuilder.Entity<TaskEntity>().HasData(task);
                }
                else if (task.GetType() == typeof(ContractEntity))
                {
                    modelBuilder.Entity<ContractEntity>().HasData(task);
                }
                else if (task.GetType() == typeof(AcceptationEntity))
                {
                    modelBuilder.Entity<AcceptationEntity>().HasData(task);
                }
                else if (task.GetType() == typeof(ArchivationEntity))
                {
                    modelBuilder.Entity<ArchivationEntity>().HasData(task);
                }
                else if (task.GetType() == typeof(AssessmentEntity))
                {
                    modelBuilder.Entity<AssessmentEntity>().HasData(task);
                }
                else if (task.GetType() == typeof(AssignmentEntity))
                {
                    modelBuilder.Entity<AssignmentEntity>().HasData(task);
                }
                else if (task.GetType() == typeof(EstimateEntity))
                {
                    modelBuilder.Entity<EstimateEntity>().HasData(task);
                }
                else if (task.GetType() == typeof(PublishEntity))
                {
                    modelBuilder.Entity<PublishEntity>().HasData(task);
                }
            }
        }
    }
}
