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
    public enum ContractTypeEnum
    {
        Other,
        Gift,
        Purchase,
        Rent,
        Employment,
        Exchange,
    }

    public static class ContractType
    {
        public static string ToLabel(this ContractTypeEnum value)
        {
            switch (value)
            {
                case ContractTypeEnum.Other:
                    return "jiná";
                
                case ContractTypeEnum.Employment:
                    return "pracovní smlouva";
                
                case ContractTypeEnum.Gift:
                    return "darovací smlouva";
                
                case ContractTypeEnum.Purchase:
                    return "kupní smlouva";
                
                case ContractTypeEnum.Rent:
                    return "nájemní slouva";
                
                case ContractTypeEnum.Exchange:
                    return "směnná smlouva";
                
                default:
                    return "jiná";
            }
        }
    }
}
