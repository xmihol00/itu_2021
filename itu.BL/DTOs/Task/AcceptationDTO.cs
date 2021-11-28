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
using itu.BL.DTOs.Task.Interfaces;
using itu.Common.Enums;

namespace itu.BL.DTOs.Task
{
    public class AcceptationDTO : DetailTaskDTO, IAcceptationDTO
    {
        public string Benefit { get; set; }
        public double PriceGues { get; set; }
        public CurrencyEnum Currency { get; set; }
        public string Reason { get; set; }
        public bool Accepted { get; set; }
    }
}
