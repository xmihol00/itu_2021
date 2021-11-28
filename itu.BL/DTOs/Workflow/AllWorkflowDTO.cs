//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       Vítek Hnatovskyj
// Kontakt:     xhnato00@stud.fit.vutbr.cz
//=================================================================================================================
using itu.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.BL.DTOs.Workflow
{
    public class AllWorkflowDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpectedEnd { get; set; }
        public WorkflowStateEnum State { get; set; }
        public List<WorkflowTaskOverviewDTO> Tasks { get; set; }
        public WorkflowTaskOverviewDTO CurrentTask { get; set; }
        public WorkflowAgendaOverviewDTO Agenda { get; set; }

    }
}
