//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       Vítek Hnatovskyj
// Kontakt:     xhnato00@stud.fit.vutbr.cz
//=================================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.BL.DTOs.Agenda
{
    public class IdNameAgendaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class IdNameAgendaDTOEqualityComparer : IEqualityComparer<IdNameAgendaDTO>
    {
        public bool Equals(IdNameAgendaDTO x, IdNameAgendaDTO y)
        {
            // Two items are equal if their keys are equal.
            return x.Id == y.Id;
        }

        public int GetHashCode(IdNameAgendaDTO obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
