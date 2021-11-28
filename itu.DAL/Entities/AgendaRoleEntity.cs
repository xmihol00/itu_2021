//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       Marek Fiala
// Kontakt:     xfiala60@stud.fit.vutbr.cz
//=================================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;

namespace itu.DAL.Entities
{
    public class AgendaRoleEntity
    {
        public int Id { get; set; }
        public TaskTypeEnum Type { get; set; }
        public int AgendaId { get; set; }
        public AgendaEntity Agenda { get; set; }
        public int? UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
