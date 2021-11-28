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
using itu.BL.DTOs.File;
using itu.BL.DTOs.Task.Interfaces;
using itu.Common.Enums;

namespace itu.BL.DTOs.Task
{
    public class ContractPostDTO : TaskPostDTO
    {
        public double FinalPrice { get; set; }
        public string PriceChangeReason { get; set; }
        public ContractTypeEnum ContractType { get; set; }
        public CurrencyEnum Currency { get; set; }
    }
}
