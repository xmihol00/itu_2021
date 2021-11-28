using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace itu.DAL.Seeds
{
    public static class ModelWorkflowSeed
    {
        public static readonly List<ModelWorkflowEntity> _modelWorkflows = new List<ModelWorkflowEntity>()
        {
            new ModelWorkflowEntity()
            {
                Id = 1,
                Name = "Rychlý model malého nákupu",
                Description = "Slouží pro nákup maximálně několika běžně dostupných položek."
            },

            new ModelWorkflowEntity()
            {
                Id = 2,
                Name = "Model pro nákup se smlouvou",
                Description = "Slouží pro nákup více položek, s dodavatelem je sepsána exkluzivní smlouva."
            },

            new ModelWorkflowEntity()
            {
                Id = 3,
                Name = "Výběrové řízení malé zakázky",
                Description = "Slouží pro malé zakázky do 100 000 Kč."
            },

            new ModelWorkflowEntity()
            {
                Id = 4,
                Name = "Výběrové řízení střední zakázky",
                Description = "Slouží pro střední zakázky do 1 000 000 Kč."
            },

            new ModelWorkflowEntity()
            {
                Id = 5,
                Name = "Výběrové řízení velké zakázky",
                Description = "Slouží pro velké zakázky nad 1 000 000 Kč. Jedná se o nejdůležitější zakázky."
            },

            new ModelWorkflowEntity()
            {
                Id = 6,
                Name = "Model pro velké nákupy",
                Description = "Slouží pro velký nákup více položek, u kterých je vyžadováno posouzení a odhad ceny. S dodavatelem je sepsána exkluzivní smlouva."
            },
        };

        public static void SeedModelWorkflows(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelWorkflowEntity>().HasData(_modelWorkflows);
        }
    }
}
