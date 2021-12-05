//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       Vítek Hnatovskyj
// Kontakt:     xhnato00@stud.fit.vutbr.cz
//=================================================================================================================

using itu.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.DAL.Entities.HelperClasses
{
    public class AllWorkflow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpectedEnd { get; set; }
        public WorkflowStateEnum State { get; set; }
        public TaskEntity CurrentTask { get; set; }
        public AgendaEntity CurrentAgenda { get; set; }
    }
}
