using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;

namespace itu.DAL.Entities
{
    public class ModelTaskEntity
    {
        public int Id { get; set; }
        public TaskTypeEnum Type { get; set; }
        public int Difficulty { get; set; }
        public List<ModelWorkflowTaskEntity> WorkflowTasks { get; set; }
    }
}
