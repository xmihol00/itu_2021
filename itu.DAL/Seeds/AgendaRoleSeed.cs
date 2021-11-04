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
    public static class AgendaRoleSeed
    {
        private static readonly List<AgendaRoleEntity> _agendaRoles = new List<AgendaRoleEntity>()
        {
            new AgendaRoleEntity()
            {
                Id = 1,
                AgendaId = 3,
                UserId = 1,
                Type = TaskTypeEnum.Assignment,
            },
            new AgendaRoleEntity()
            {
                Id = 2,
                AgendaId = 3,
                UserId = 1,
                Type = TaskTypeEnum.Acceptation,
            },
            new AgendaRoleEntity()
            {
                Id = 3,
                AgendaId = 3,
                UserId = 1,
                Type = TaskTypeEnum.Assessment,
            },
            new AgendaRoleEntity()
            {
                Id = 4,
                AgendaId = 3,
                UserId = 1,
                Type = TaskTypeEnum.Estimate,
            },
            new AgendaRoleEntity()
            {
                Id = 6,
                AgendaId = 3,
                UserId = 1,
                Type = TaskTypeEnum.Contract,
            },
            new AgendaRoleEntity()
            {
                Id = 7,
                AgendaId = 3,
                UserId = 1,
                Type = TaskTypeEnum.Publish,
            },
            new AgendaRoleEntity()
            {
                Id = 8,
                AgendaId = 3,
                UserId = 1,
                Type = TaskTypeEnum.Archivation,
            },

            new AgendaRoleEntity()
            {
                Id = 9,
                AgendaId = 1,
                UserId = 1,
                Type = TaskTypeEnum.Assignment,
            },
            new AgendaRoleEntity()
            {
                Id = 10,
                AgendaId = 1,
                UserId = 1,
                Type = TaskTypeEnum.Acceptation,
            },


            new AgendaRoleEntity()
            {
                Id = 11,
                AgendaId = 2,
                UserId = 1,
                Type = TaskTypeEnum.Assignment,
            },
            new AgendaRoleEntity()
            {
                Id = 12,
                AgendaId = 2,
                UserId = 2,
                Type = TaskTypeEnum.Acceptation,
            },
            new AgendaRoleEntity()
            {
                Id = 13,
                AgendaId = 2,
                UserId = 2,
                Type = TaskTypeEnum.Estimate,
            },
            new AgendaRoleEntity()
            {
                Id = 14,
                AgendaId = 2,
                UserId = 1,
                Type = TaskTypeEnum.Estimate,
            },
            new AgendaRoleEntity()
            {
                Id = 15,
                AgendaId = 2,
                UserId = 1,
                Type = TaskTypeEnum.Contract,
            },
            new AgendaRoleEntity()
            {
                Id = 16,
                AgendaId = 2,
                UserId = 2,
                Type = TaskTypeEnum.Contract,
            },
            new AgendaRoleEntity()
            {
                Id = 17,
                AgendaId = 2,
                UserId = 2,
                Type = TaskTypeEnum.Publish,
            },
            new AgendaRoleEntity()
            {
                Id = 18,
                AgendaId = 2,
                UserId = 1,
                Type = TaskTypeEnum.Archivation,
            },
        };

        public static void SeedAgendaRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgendaRoleEntity>().HasData(_agendaRoles);
        }
    }
}
