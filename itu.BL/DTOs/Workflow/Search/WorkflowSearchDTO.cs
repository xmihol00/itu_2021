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
        public List<string> TaskNames { get; set; }
        public List<string> AgendaNames { get; set; }
        public List<string> WorkflowModelsNames { get; set; }
    }
}
