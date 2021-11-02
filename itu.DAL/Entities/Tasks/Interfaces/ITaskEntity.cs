using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;
using itu.DAL.Entities.Tasks;

namespace itu.DAL.Entities.Tasks.Interfaces
{
    public interface ITaskEntity
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Note { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public PriorityEnum Priority { get; set; }
        public string DelayReason { get; set; }
        public bool Active { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public int WorkflowId { get; set; }
        public WorkflowEntity Workflow { get; set; }
    }
}