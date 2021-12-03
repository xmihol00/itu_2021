//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       Vítek Hnatovskyj
// Kontakt:     xhnato00@stud.fit.vutbr.cz
//=================================================================================================================
using itu.BL.DTOs.Agenda;
using itu.BL.DTOs.File;
using itu.BL.DTOs.Task;
using itu.Common.Enums;
using itu.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.BL.DTOs.Workflow
{
    public class DetailWorkflowDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public WorkflowStateEnum State { get; set; }
        public DateTime ExpectedEnd { get; set; }

        public IdNameAgendaDTO Agenda { get; set; }
        public IdNameModelDTO ModelWorkflowIdName { get; set; }
        public ModelWorkflowEntity ModelWorkflow { get; set; }
        public List<DetailTaskDTO> Tasks { get; set; }
        public TaskEntity CurrentTask { get; set; }
        public List<AllFileDTO> Files { get; set; }
    }
}
