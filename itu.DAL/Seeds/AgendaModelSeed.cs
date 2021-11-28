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
using Microsoft.EntityFrameworkCore;

namespace itu.DAL.Seeds
{
    public static class AgendaModelSeed
    {
        private static readonly List<AgendaModelEntity> _agendaModels = new List<AgendaModelEntity>()
        {
            new AgendaModelEntity()
            {
               AgendaId = 1,
               ModelId = 1, 
            },
            new AgendaModelEntity()
            {
               AgendaId = 2,
               ModelId = 2, 
            },
            new AgendaModelEntity()
            {
               AgendaId = 2,
               ModelId = 3,
            },
            new AgendaModelEntity()
            {
               AgendaId = 2,
               ModelId = 4, 
            },
            new AgendaModelEntity()
            {
               AgendaId = 3,
               ModelId = 5, 
            }
        };

        public static void SeedAgendaModels(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgendaModelEntity>().HasData(_agendaModels);
        }
    }
}
