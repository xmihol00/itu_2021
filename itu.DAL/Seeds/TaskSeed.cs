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
                Active = false,
                End = DateTime.Now.AddDays(-16),
                Currency = CurrencyEnum.EUR,
                Priority = PriorityEnum.Low,
                Note = "Testovaci předvyplněný úkol obsahující i poznámku.",
                PriceGues = 7369821,
                Start = DateTime.Now.AddDays(-20),
                Benefit = "Testovací předvyplněný úkol obsahující i přínos organizaci.",
            },
            new AcceptationEntity()
            {
                Id = 2,
                UserId = 2,
                WorkflowId = 1,
                Active = false,
                End = DateTime.Now.AddDays(-13),
                Priority = PriorityEnum.Medium,
                Accepted = true,
                Note = "Přijato bez výhrad",
                Reason = "Pěkně vypracováno",
                DelayReason = "dovolená",
                Benefit = "Testovací předvyplněný úkol obsahující i přínos organizaci.",
                Currency = CurrencyEnum.EUR,
                PriceGues = 7369821,
                Start = DateTime.Now.AddDays(-16),
                Order = 2,
            },
            new EstimateEntity()
            {
                Id = 3,
                UserId = 3,
                WorkflowId = 1,
                Active = false,
                End = DateTime.Now.AddDays(-7),
                Priority = PriorityEnum.Urgent,
                Start = DateTime.Now.AddDays(-13),
                Currency = CurrencyEnum.EUR,
                EstimatePrice = 8632148,
                MaxPrice = 10000000,
                Order = 3,
            },
            new AssessmentEntity()
            {
                Id = 4,
                UserId = 2,
                WorkflowId = 1,
                Active = false,
                End = DateTime.Now.AddDays(-3),
                Priority = PriorityEnum.Medium,
                Start = DateTime.Now.AddDays(-7),
                Conclusion = "Vše se zdá být v pořádku, cena odpovídá.",
                Order = 4,
            },
            new ContractEntity()
            {
                Id = 5,
                UserId = 1,
                WorkflowId = 1,
                Active = true,
                End = DateTime.Now.AddDays(15),
                Priority = PriorityEnum.High,
                Start = DateTime.Now.AddDays(-3),
                Order = 5
            },



            new AssignmentEntity()
            {
                Id = 6,
                UserId = 5,
                WorkflowId = 2,
                Active = false,
                End = DateTime.Now.AddDays(-5),
                Priority = PriorityEnum.Low,
                Start = DateTime.Now.AddDays(-8),
                Benefit = "Všichni nás pak budou mít rádi :).",
                Currency = CurrencyEnum.CZK,
                PriceGues = 26320,
                Order = 1,
            },
            new AcceptationEntity()
            {
                Id = 7,
                UserId = 2,
                WorkflowId = 2,
                Active = true,
                End = DateTime.Now.AddDays(5),
                Priority = PriorityEnum.Urgent,
                Start = DateTime.Now.AddDays(-5),
                Order = 2,
            },


            new AssignmentEntity()
            {
                Id = 8,
                UserId = 1,
                WorkflowId = 3,
                Active = true,
                End = DateTime.Now.AddDays(40),
                Priority = PriorityEnum.Medium,
                Start = DateTime.Now.AddDays(-1),
                Order = 1,
            },


            new AssignmentEntity()
            {
                Id = 9,
                UserId = 5,
                WorkflowId = 4,
                Active = false,
                End = DateTime.Now.AddDays(-5),
                Priority = PriorityEnum.Medium,
                Start = DateTime.Now.AddDays(-15),
                Order = 1,
                Benefit = "Místo 8 zahradnílů nám budou stačit 4.",
                PriceGues = 3335.41,
                Currency = CurrencyEnum.USD,
            },
            new AcceptationEntity()
            {
                Id = 10,
                UserId = 3,
                WorkflowId = 4,
                Active = false,
                End = DateTime.Now.AddDays(-2),
                Priority = PriorityEnum.Medium,
                Start = DateTime.Now.AddDays(-5),
                Order = 2,
                Benefit = "Místo 8 zahradnílů nám budou stačit 4.",
                PriceGues = 3335.41,
                Currency = CurrencyEnum.USD,
                Accepted = true,
                Reason = "Ano, to by se mělo vyplatit.."
            },
            new EstimateEntity()
            {
                Id = 11,
                UserId = 1,
                WorkflowId = 4,
                Active = true,
                End = DateTime.Now.AddDays(26),
                Priority = PriorityEnum.Urgent,
                Start = DateTime.Now.AddDays(-2),
                Order = 3,
            },


            new AssignmentEntity()
            {
                Id = 12,
                UserId = 1,
                WorkflowId = 5,
                Active = false,
                End = DateTime.Now.AddDays(-18),
                Priority = PriorityEnum.High,
                Start = DateTime.Now.AddDays(-25),
                Order = 1,
                Benefit = "Nebudeme muset zaměstnancum platit přesčasy za úklid.",
                PriceGues = 23515.41,
                Currency = CurrencyEnum.CZK,
                Note = "Cena je měsíčně."
            },
            new AcceptationEntity()
            {
                Id = 13,
                UserId = 1,
                WorkflowId = 5,
                Active = false,
                End = DateTime.Now.AddDays(-13),
                Priority = PriorityEnum.Medium,
                Start = DateTime.Now.AddDays(-18),
                Order = 2,
                Benefit = "Nebudeme muset zaměstnancum platit přesčasy za úklid.",
                PriceGues = 23515.41,
                Currency = CurrencyEnum.CZK,
                Note = "Cena je měsíčně.",
                Accepted = true,
                Reason = "Snad se to vyplatí."
            },
            new ContractEntity()
            {
                Id = 14,
                UserId = 3,
                WorkflowId = 5,
                Active = false,
                End = DateTime.Now.AddDays(-4),
                Priority = PriorityEnum.Low,
                Start = DateTime.Now.AddDays(-13),
                Order = 3,
                ContractType = ContractTypeEnum.Employment,
                FinalPrice = 25600,
                PriceChangeReason = "Je teď těžké sehnat uklízeče, nutno zvýčit odměnu.",
                Currency = CurrencyEnum.CZK,
                Note = "Je to DPP.",
            },
            new PublishEntity()
            {
                Id = 15,
                UserId = 2,
                WorkflowId = 5,
                Active = true,
                End = DateTime.Now.AddDays(9),
                Priority = PriorityEnum.High,
                Start = DateTime.Now.AddDays(-4),
                Order = 4,
            },


            new AssignmentEntity()
            {
                Id = 16,
                UserId = 1,
                WorkflowId = 6,
                Active = false,
                End = DateTime.Now.AddDays(-29),
                Priority = PriorityEnum.High,
                Start = DateTime.Now.AddDays(-40),
                Order = 1,
                Benefit = "Uvidíme i pohled z jiného úhlu.",
                PriceGues = 245321,
                Currency = CurrencyEnum.CZK,
            },
            new AcceptationEntity()
            {
                Id = 17,
                UserId = 1,
                WorkflowId = 6,
                Active = false,
                End = DateTime.Now.AddDays(-22),
                Priority = PriorityEnum.Medium,
                Start = DateTime.Now.AddDays(-29),
                Order = 2,
                Benefit = "Uvidíme i pohled z jiného úhlu.",
                PriceGues = 245321,
                Currency = CurrencyEnum.CZK,
                Accepted = true,
                Reason = "Ano, tuto investici je možné ospravedlnit."
            },
            new EstimateEntity()
            {
                Id = 18,
                UserId = 2,
                WorkflowId = 6,
                Active = false,
                End = DateTime.Now.AddDays(-13),
                Priority = PriorityEnum.Medium,
                Start = DateTime.Now.AddDays(-22),
                Order = 3,
                Currency = CurrencyEnum.CZK,
                EstimatePrice = 225000,
                MaxPrice = 275000,
            },
            new ContractEntity()
            {
                Id = 19,
                UserId = 3,
                WorkflowId = 6,
                Active = false,
                End = DateTime.Now.AddDays(-4),
                Priority = PriorityEnum.Low,
                Start = DateTime.Now.AddDays(-13),
                Order = 4,
                ContractType = ContractTypeEnum.Purchase,
                FinalPrice = 225000,
                Currency = CurrencyEnum.CZK,
            },
            new PublishEntity()
            {
                Id = 20,
                UserId = 2,
                WorkflowId = 6,
                Active = false,
                End = DateTime.Now.AddDays(-2),
                Priority = PriorityEnum.High,
                Start = DateTime.Now.AddDays(-4),
                Order = 5,
                PublishStart = DateTime.Now.AddDays(25),
                PublishEnd = DateTime.Now.AddDays(55),
            },
            new ArchivationEntity()
            {
                Id = 21,
                UserId = 1,
                WorkflowId = 6,
                Active = true,
                End = DateTime.Now.AddDays(16),
                Priority = PriorityEnum.Low,
                Start = DateTime.Now.AddDays(-2),
                Order = 6,
            },


            new AssignmentEntity()
            {
                Id = 22,
                UserId = 1,
                WorkflowId = 7,
                Active = false,
                End = DateTime.Now.AddDays(-26),
                Priority = PriorityEnum.High,
                Start = DateTime.Now.AddDays(-34),
                Order = 1,
                Benefit = "Potřebujeme drony pro střežení pozemku!",
                PriceGues = 1450,
                Currency = CurrencyEnum.USD,
            },
            new AcceptationEntity()
            {
                Id = 23,
                UserId = 3,
                WorkflowId = 7,
                Active = false,
                End = DateTime.Now.AddDays(-20),
                Priority = PriorityEnum.Medium,
                Start = DateTime.Now.AddDays(-26),
                Order = 2,
                Benefit = "Potřebujeme drony pro střežení pozemku!",
                PriceGues = 1450,
                Currency = CurrencyEnum.USD,
                Accepted = true,
                Reason = "To bude super!"
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
