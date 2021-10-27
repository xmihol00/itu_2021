using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.DAL.Entities
{
    public class ModelWorkflowTaskEntity
    {
        public int ModelWorkflowId { get; set; }
        public ModelWorkflowEntity ModelWorkflow { get; set; }
        public int ModelTaskId { get; set; }
        public ModelTaskEntity ModelTask { get; set; }
        public int Order { get; set; }
    }
}
