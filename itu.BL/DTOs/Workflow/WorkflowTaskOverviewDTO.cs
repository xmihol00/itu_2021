//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       Vítek Hnatovskyj
// Kontakt:     xhnato00@stud.fit.vutbr.cz
//=================================================================================================================
using itu.DAL.Entities.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.BL.DTOs.Workflow
{
    public class WorkflowTaskOverviewDTO
    {
        public int Id { get; set; }
        public DateTime End { get; set; }
        public bool Active { get; set; }
        public int Order { get; set; }
        public string Type { get; set; }
    }
}
