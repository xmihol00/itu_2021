using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.BL.DTOs.Task.Interfaces;
using itu.Common.Enums;

namespace itu.BL.DTOs.Task
{
    public class DetailTaskDTO : IDetailTaskDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string WorkflowName { get; set; }
        public string AgendaName { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
        public string Requirements { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public PriorityEnum Priority { get; set; }
        public string DelayReason { get; set; }
        public bool Active { get; set; }
        public int? PreviousId { get; set; }
        public int? NextId { get; set; }
        public int WorkflowId { get; set; }
        public int AgendaId { get; set; }
    }
}
