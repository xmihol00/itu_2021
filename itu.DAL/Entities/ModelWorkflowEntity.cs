using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.DAL.Entities
{
    public class ModelWorkflowEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<WorkflowEntity> Worflows { get; set; }
        public List<ModelWorkflowTaskEntity> WorkflowTasks { get; set; }
    }
}
