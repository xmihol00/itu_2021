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

namespace itu.Common.Enums
{
    public enum PriorityEnum
    {
        Urgent,
        High,
        Medium,
        Low,
    }

    public static class Priority
    {
        public static string ToLabel(this PriorityEnum value)
        {
            switch (value)
            {
                case PriorityEnum.Low:
                    return "odložitelný";
                
                case PriorityEnum.Medium:
                    return "běžný";
                
                case PriorityEnum.High:
                    return "nalehavý";

                case PriorityEnum.Urgent:
                    return "urgentní";
                
                default:
                    return "";
            }
        }
    }
}
