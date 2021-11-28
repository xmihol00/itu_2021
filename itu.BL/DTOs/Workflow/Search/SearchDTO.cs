//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       Vítek Hnatovskyj
// Kontakt:     xhnato00@stud.fit.vutbr.cz
//=================================================================================================================
using itu.BL.DTOs.Agenda;
using itu.BL.DTOs.Task;
using itu.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.BL.DTOs.Workflow.Search
{
    public class SearchDTO
    {
        public uint Results { get; set; }
        public List<IdNameAgendaDTO> Agendas { get; set; }
        public List<IdNameModelDTO> WorkflowModels { get; set; }
        public List<IdTypeTaskDTO> ActiveTasks { get; set; }
        public FilterTypesEnum FilterType { get; set; }

    }
}
