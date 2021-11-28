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
using itu.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace itu.DAL.Seeds
{
    public static class ModelWorkflowTaskSeed
    {
        public static readonly List<ModelWorkflowTaskEntity> _workflowTasks = new List<ModelWorkflowTaskEntity>()
        {
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 1,
                ModelWorkflowId = 1,
                Order = 1
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 101,
                ModelWorkflowId = 1,
                Order = 2
            },


            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 1,
                ModelWorkflowId = 2,
                Order = 1
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 102,
                ModelWorkflowId = 2,
                Order = 2
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 402,
                ModelWorkflowId = 2,
                Order = 3
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 603,
                ModelWorkflowId = 2,
                Order = 4
            },


            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 2,
                ModelWorkflowId = 3,
                Order = 1
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 102,
                ModelWorkflowId = 3,
                Order = 2
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 402,
                ModelWorkflowId = 3,
                Order = 3
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 501,
                ModelWorkflowId = 3,
                Order = 4
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 602,
                ModelWorkflowId = 3,
                Order = 5
            },


            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 2,
                ModelWorkflowId = 4,
                Order = 1
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 102,
                ModelWorkflowId = 4,
                Order = 2
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 303,
                ModelWorkflowId = 4,
                Order = 3
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 402,
                ModelWorkflowId = 4,
                Order = 4
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 502,
                ModelWorkflowId = 4,
                Order = 5
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 601,
                ModelWorkflowId = 4,
                Order = 6
            },


            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 3,
                ModelWorkflowId = 5,
                Order = 1
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 103,
                ModelWorkflowId = 5,
                Order = 2
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 203,
                ModelWorkflowId = 5,
                Order = 3
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 303,
                ModelWorkflowId = 5,
                Order = 4
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 403,
                ModelWorkflowId = 5,
                Order = 5
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 503,
                ModelWorkflowId = 5,
                Order = 6
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 603,
                ModelWorkflowId = 5,
                Order = 7
            },

            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 2,
                ModelWorkflowId = 6,
                Order = 1
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 102,
                ModelWorkflowId = 6,
                Order = 2
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 201,
                ModelWorkflowId = 6,
                Order = 3
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 302,
                ModelWorkflowId = 6,
                Order = 4
            },
            new ModelWorkflowTaskEntity()
            {
                ModelTaskId = 403,
                ModelWorkflowId = 6,
                Order = 5
            },
        };

        public static void SeedModelWorkflowTasks(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelWorkflowTaskEntity>().HasData(_workflowTasks);
        }
    }
}
