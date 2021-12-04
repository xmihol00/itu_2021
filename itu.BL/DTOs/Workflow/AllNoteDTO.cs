using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;

namespace itu.BL.DTOs.Workflow
{
    public class AllNoteDTO
    {
        public string Note { get; set; }
        public WorkflowStateEnum Before { get; set; }
        public WorkflowStateEnum After { get; set; }
        public DateTime Created { get; set; }
    }
}
