using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;
using itu.DAL.Entities;
using itu.DAL.Entities.Tasks;
using Microsoft.EntityFrameworkCore;

namespace itu.DAL.Seeds
{
    public static class TaskSeed
    {
        private static readonly List<TaskEntity> _task = new List<TaskEntity>()
        {
            new AssignmentEntity()
            {
                Id = 1,
                Active = true,
                DelayReason = "",
                OrderName = "First Order",
                Start = DateTime.Now.AddDays(-3),
                End = DateTime.Now.AddDays(8),
                Name = "Order Assignment",
                PreviousId = null,
                NextId = 2,
                Reason = "We need this!",
                FormNumber = "855AAVFS66",
                Note = "This is just an ordinary order.",
                Price = 56_251.50,
                Priority = PriorityEnum.Normal,
                UserId = 1,
            },

            new AcceptationEntity()
            {
                Id = 2,
                Active = false,
                DelayReason = "",
                Name = "Acceptition Order",
                Accepted = false,
                Priority = PriorityEnum.Low,
                UserId = 1,
            }
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
