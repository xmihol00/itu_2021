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
    public enum LocationEnum
    {
        MainStore,
        SideStore,
        Temporary,
    }

    public static class Location
    {
        public static string ToLabel(this LocationEnum location)
        {
            switch (location)
            {
                case LocationEnum.MainStore:
                    return "hlavní sklad dokumentů";
                
                case LocationEnum.SideStore:
                    return "vedlejší sklad dokumentů";
                
                case LocationEnum.Temporary:
                    return "prozatimní sklad dokumentů";
                
                default:
                    return "";
            }
        }
    }
}
