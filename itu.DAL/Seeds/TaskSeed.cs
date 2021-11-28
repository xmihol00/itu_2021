//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       David Mihola
// Kontakt:     xmihol00@stud.fit.vutbr.cz
//=================================================================================================================

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
                Order = 1,
                UserId = 1,
                WorkflowId = 1,
                Active = true,
                End = DateTime.Now.AddDays(3),
                Currency = CurrencyEnum.EUR,
                Priority = PriorityEnum.Low,
                DelayReason = "Testovací důvod vrácení",
                Note = "Testovaci předvyplněný úkol obsahující i poznámku.",
                PriceGues = 4368.2,
                Start = DateTime.Now.AddDays(-3),
                Benefit = "Testovací předvyplněný úkol obsahující i přínos organizaci."
            },

            new AcceptationEntity()
            {
                Id = 2,
                UserId = 1,
                WorkflowId = 2,
                Active = true,
                End = DateTime.Now.AddDays(-7),
                Priority = PriorityEnum.Medium,
                Accepted = true,
                Note = "Přijato bez výhrad",
                Reason = "Pěkně vypracováno",
                DelayReason = "dovolená",
                Start = DateTime.Now.AddDays(-7),
            },

            new AssessmentEntity()
            {
                Id = 3,
                UserId = 1,
                WorkflowId = 3,
                Active = true,
                End = DateTime.Now.AddDays(12),
                Priority = PriorityEnum.High,
                Start = DateTime.Now.AddDays(-2),
            },

            new EstimateEntity()
            {
                Id = 4,
                UserId = 1,
                WorkflowId = 4,
                Active = true,
                End = DateTime.Now.AddDays(4),
                Priority = PriorityEnum.Urgent,
                Start = DateTime.Now.AddDays(-9),
            },

            new ContractEntity()
            {
                Id = 5,
                UserId = 1,
                WorkflowId = 5,
                Active = true,
                End = DateTime.Now.AddDays(4),
                Priority = PriorityEnum.Medium,
                Start = DateTime.Now.AddDays(-4),
            },

            new PublishEntity()
            {
                Id = 6,
                UserId = 1,
                WorkflowId = 6,
                Active = true,
                End = DateTime.Now.AddDays(-2),
                Priority = PriorityEnum.Low,
                Start = DateTime.Now.AddDays(-1),
            },

            new ArchivationEntity()
            {
                Id = 7,
                UserId = 1,
                WorkflowId = 7,
                Active = true,
                End = DateTime.Now.AddDays(4),
                Priority = PriorityEnum.High,
                Start = DateTime.Now.AddDays(-6),
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
