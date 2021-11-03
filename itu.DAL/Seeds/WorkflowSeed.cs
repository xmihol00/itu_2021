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
                AgendaId = 3,
                Name = "1. testovací úkol",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam rhoncus aliquam metus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Sed vel lectus. Donec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut, suscipit at, pharetra vitae, orci.",
                State = WorkflowStateEnum.Active,
                ModelWorkflowId = 1
            },
            new WorkflowEntity()
            {
                Id = 2,
                AgendaId = 2,
                Name = "2. testovací úkol",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam rhoncus aliquam metus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Sed vel lectus. Donec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui.",
                State = WorkflowStateEnum.Active,
                ModelWorkflowId = 2
            },
            new WorkflowEntity()
            {
                Id = 3,
                AgendaId = 1,
                Name = "3. testovací úkol",
                Description = "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Sed vel lectus. Donec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut, suscipit at, pharetra vitae, orci.",
                State = WorkflowStateEnum.Active,
                ModelWorkflowId = 3
            },
            new WorkflowEntity()
            {
                Id = 4,
                AgendaId = 1,
                Name = "4. testovací úkol",
                Description = "Per inceptos hymenaeos. Sed vel lectus. Donec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut, suscipit at, pharetra vitae, orci.",
                State = WorkflowStateEnum.Active,
                ModelWorkflowId = 4
            },
            new WorkflowEntity()
            {
                Id = 5,
                AgendaId = 2,
                Name = "5. testovací úkol",
                Description = "Per inceptos hymenaeos. Sed vel lectus. Donec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut, suscipit at, pharetra vitae, orci.",
                State = WorkflowStateEnum.Active,
                ModelWorkflowId = 3
            },
            new WorkflowEntity()
            {
                Id = 6,
                AgendaId = 3,
                Name = "6. testovací úkol",
                Description = "Per inceptos hymenaeos. Sed vel lectus. Donec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut.",
                State = WorkflowStateEnum.Active,
                ModelWorkflowId = 5
            },
            new WorkflowEntity()
            {
                Id = 7,
                AgendaId = 2,
                Name = "7. testovací úkol",
                Description = "Donec odio tempus molestie, porttitor ut, iaculis quis. Per inceptos hymenaeos. Sed vel lectus. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut, suscipit at, pharetra vitae, orci.",
                State = WorkflowStateEnum.Active,
                ModelWorkflowId = 5
            },
        };

        public static void SeedWorkflows(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkflowEntity>().HasData(_workflows);
        }
    }
}
