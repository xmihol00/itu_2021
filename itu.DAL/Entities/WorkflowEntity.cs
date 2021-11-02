using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;

namespace itu.DAL.Entities
{
    public class WorkflowEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Creation { get; set; }
        public DateTime ExpectedEnd { get; set; }
        public WorkflowStateEnum State { get; set; }
        public int AgendaId { get; set; }
        public AgendaEntity Agenda { get; set; }
        public int ModelWorkflowId { get; set; }
        public ModelWorkflowEntity ModelWorkflow { get; set; }
        public List<NoteEntity> Notes { get; set; }
        public List<TaskEntity> Tasks { get; set; }
        public List<FileEntity> Files { get; set; }
    }
}
