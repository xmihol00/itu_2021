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

namespace itu.BL.DTOs.Agenda
{
    public class WorkflowStateDTO
    {
        public int AgendaId { get; set; }
        public int WorkflowId { get; set; }
        public WorkflowStateEnum State { get; set; }
        public string Note { get; set; }
    }
}
