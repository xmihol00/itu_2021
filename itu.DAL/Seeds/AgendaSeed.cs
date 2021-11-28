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
    public static class AgendaSeed
    {
        private static readonly List<AgendaEntity> _agendas = new List<AgendaEntity>()
        {
            new AgendaEntity()
            {
                Id = 1,
                Name = "Nákupy",
                Creation = DateTime.Now.AddDays(-30),
                Description = "Agenda správující jednoduchuché nákupy bez vúběrových řízení",
                AdministratorId = 1,
            },
            new AgendaEntity()
            {
                Id = 2,
                Name = "Malé a střední zakázky",
                Creation = DateTime.Now.AddDays(-5),
                Description = "Agenda spravující menší a střední zakázky",
                AdministratorId = 2,
            },
            new AgendaEntity()
            {
                Id = 3,
                Name = "Velké zakázky",
                Creation = DateTime.Now.AddDays(-60),
                Description = "Agenda spravující důležité velké zakázky",
                AdministratorId = 1,
            },
        };

        public static void SeedAgendas(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgendaEntity>().HasData(_agendas);
        }
    }
}
