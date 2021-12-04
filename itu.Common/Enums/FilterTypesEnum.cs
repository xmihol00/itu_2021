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

namespace itu.Common.Enums
{
    public enum FilterTypesEnum
    {
        Selected = 0,
        Agenda,
        Task,
        Workflow
    }
    public static class FilterType
    {
        public static readonly string[] SearchTypes = { "Vybrané", "Agendy", "Aktivní úkoly", "Workflow" };

        public static string ToLabel(this FilterTypesEnum filterType)
        {
            return SearchTypes[(int)filterType];
        }
    }
}
