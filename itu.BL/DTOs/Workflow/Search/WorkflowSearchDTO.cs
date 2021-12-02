//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       Vítek Hnatovskyj
// Kontakt:     xhnato00@stud.fit.vutbr.cz
//=================================================================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.BL.DTOs.Workflow.Search
{
    public class WorkflowSearchDTO
    {
        public List<int> TaskIds { get; set; }
        public List<int> AgendaIds { get; set; }
        public List<int> WorkflowModelsIds { get; set; }
      
        public string SearchString { get; set; }
    }
}
