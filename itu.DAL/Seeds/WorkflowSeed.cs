using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;
using itu.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace itu.DAL.Seeds
{
    public static class WorkflowSeed
    {
        public static readonly List<WorkflowEntity> _workflows = new List<WorkflowEntity>()
        {
            new WorkflowEntity()
            {
                Id = 1,
                AgendaId = 2,
                Name = "Testovací úkol",
                State = WorkflowStateEnum.Active,
                ModelWorkflowId = 1
            }
        };

        public static void SeedWorkflows(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkflowEntity>().HasData(_workflows);
        }
    }
}
