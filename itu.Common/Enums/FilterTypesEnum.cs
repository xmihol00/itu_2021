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

        /// <summary>
        /// Slovni popisy jednotlivych vyhledavacich typu.
        /// </summary>
        public static readonly string[] SearchTypes = { "Vybrané", "Agendy", "Aktivní úkoly", "Workflow" };

        /// <summary>
        /// Prevadi hodnoty z enum na jejich slovni popisy pouzite ve views.
        /// </summary>
        /// <param name="filterType">FilterTypesEnum typ filteru</param>
        /// <returns>Slovni popis filteru</returns>
        public static string ToLabel(this FilterTypesEnum filterType)
        {
            return SearchTypes[(int)filterType];
        }
    }
}
