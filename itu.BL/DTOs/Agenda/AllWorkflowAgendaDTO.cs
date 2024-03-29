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
    public class AllWorkflowAgendaDTO
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public PriorityEnum Priority { get; set; }
        public DateTime End { get; set; }
        public TaskTypeEnum TaskType { get; set; }
        public int TaskOrder { get; set; }
        public int ModelId { get; set; }
        public WorkflowStateEnum State { get; set; }
    }
}
