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
                UserId = 1,
                WorkflowId = 1,
                Active = true,
                End = DateTime.Now.AddDays(3),
                Currency = CurrencyEnum.EUR,
                NextId = 2,
                PreviousId = null,
                Priority = PriorityEnum.Low,
                DelayReason = "Testovací důvod vrácení",
                Note = "Testovaci předvyplněný úkol obsahující i poznámku.",
                PriceGues = 4368.2,
                Start = DateTime.Now.AddDays(-3),
                Reason = "Testovací důvod vypsání tohoto úkolu."
            },

            new AcceptationEntity()
            {
                Id = 2,
                UserId = 1,
                WorkflowId = 1,
                Active = false,
                End = DateTime.Now.AddDays(25),
                PreviousId = 1,
                NextId = 3,
                Priority = PriorityEnum.Medium,
                Accepted = true,
                Note = "Přijato bez výhrad",
                Reason = "Pěkně vypracováno",
                DelayReason = "dovolená",
            },

            new AssessmentEntity()
            {
                Id = 3,
                UserId = 1,
                WorkflowId = 1,
                Active = false,
                PreviousId = 2,
                NextId = 4,
                Priority = PriorityEnum.High,
            },

            new EstimateEntity()
            {
                Id = 4,
                UserId = 1,
                WorkflowId = 1,
                Active = false,
                PreviousId = 3,
                NextId = 5,
                Priority = PriorityEnum.Urgent,
            },

            new ContractEntity()
            {
                Id = 5,
                UserId = 1,
                WorkflowId = 1,
                Active = false,
                PreviousId = 4,
                NextId = 6,
            },

            new PublishEntity()
            {
                Id = 6,
                UserId = 1,
                WorkflowId = 1,
                Active = false,
                PreviousId = 5,
                NextId = 7,
            },

            new PublishEntity()
            {
                Id = 7,
                UserId = 1,
                WorkflowId = 1,
                Active = false,
                PreviousId = 6,
                NextId = null,
            },
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
