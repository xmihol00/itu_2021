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
    public static class ModelTaskSeed
    {
        public static readonly List<ModelTaskEntity> _modelTaks = new List<ModelTaskEntity>()
        {
            new ModelTaskEntity()
            {
                Id = 1,
                Type = TaskTypeEnum.Assignment,
                Difficulty = TimeSpan.FromDays(5)
            },
            new ModelTaskEntity()
            {
                Id = 2,
                Type = TaskTypeEnum.Assignment,
                Difficulty = TimeSpan.FromDays(10)
            },
            new ModelTaskEntity()
            {
                Id = 3,
                Type = TaskTypeEnum.Assignment,
                Difficulty = TimeSpan.FromDays(15)
            },

            new ModelTaskEntity()
            {
                Id = 101,
                Type = TaskTypeEnum.Acceptation,
                Difficulty = TimeSpan.FromDays(5)
            },
            new ModelTaskEntity()
            {
                Id = 102,
                Type = TaskTypeEnum.Acceptation,
                Difficulty = TimeSpan.FromDays(10)
            },
            new ModelTaskEntity()
            {
                Id = 103,
                Type = TaskTypeEnum.Acceptation,
                Difficulty = TimeSpan.FromDays(15)
            },

            new ModelTaskEntity()
            {
                Id = 201,
                Type = TaskTypeEnum.Assessment,
                Difficulty = TimeSpan.FromDays(5)
            },
            new ModelTaskEntity()
            {
                Id = 202,
                Type = TaskTypeEnum.Assessment,
                Difficulty = TimeSpan.FromDays(10)
            },
            new ModelTaskEntity()
            {
                Id = 203,
                Type = TaskTypeEnum.Assessment,
                Difficulty = TimeSpan.FromDays(15)
            },

            new ModelTaskEntity()
            {
                Id = 301,
                Type = TaskTypeEnum.Estimate,
                Difficulty = TimeSpan.FromDays(5)
            },
            new ModelTaskEntity()
            {
                Id = 302,
                Type = TaskTypeEnum.Estimate,
                Difficulty = TimeSpan.FromDays(10)
            },
            new ModelTaskEntity()
            {
                Id = 303,
                Type = TaskTypeEnum.Estimate,
                Difficulty = TimeSpan.FromDays(15)
            },

            new ModelTaskEntity()
            {
                Id = 401,
                Type = TaskTypeEnum.Contract,
                Difficulty = TimeSpan.FromDays(5)
            },
            new ModelTaskEntity()
            {
                Id = 402,
                Type = TaskTypeEnum.Contract,
                Difficulty = TimeSpan.FromDays(10)
            },
            new ModelTaskEntity()
            {
                Id = 403,
                Type = TaskTypeEnum.Contract,
                Difficulty = TimeSpan.FromDays(15)
            },

            new ModelTaskEntity()
            {
                Id = 501,
                Type = TaskTypeEnum.Publish,
                Difficulty = TimeSpan.FromDays(5)
            },
            new ModelTaskEntity()
            {
                Id = 502,
                Type = TaskTypeEnum.Publish,
                Difficulty = TimeSpan.FromDays(10)
            },
            new ModelTaskEntity()
            {
                Id = 503,
                Type = TaskTypeEnum.Publish,
                Difficulty = TimeSpan.FromDays(15)
            },

            new ModelTaskEntity()
            {
                Id = 601,
                Type = TaskTypeEnum.Archivation,
                Difficulty = TimeSpan.FromDays(5)
            },
            new ModelTaskEntity()
            {
                Id = 602,
                Type = TaskTypeEnum.Archivation,
                Difficulty = TimeSpan.FromDays(10)
            },
            new ModelTaskEntity()
            {
                Id = 603,
                Type = TaskTypeEnum.Archivation,
                Difficulty = TimeSpan.FromDays(15)
            },
        };

        public static void SeedModelTasks(this ModelBuilder modelBuilder)
        {
            foreach (ModelTaskEntity modelTaks in _modelTaks)
            {
                modelBuilder.Entity<ModelTaskEntity>().HasData(modelTaks);
            }
        }
    }
}
