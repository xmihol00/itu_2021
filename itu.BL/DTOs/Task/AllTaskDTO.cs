using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;

namespace itu.BL.DTOs.Task
{
    public class AllTaskDTO
    {
        public int Id { get; set; }
        public string WorkflowName { get; set; }
        public string Type { get; set; }
        public DateTime End { get; set; }
        public PriorityEnum Priority { get; set; }
        public int WorkflowId { get; set; }
        public int AgendaId { get; set; }
    }
}
