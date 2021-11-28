//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       Vítek Hnatovskyj
// Kontakt:     xhnato00@stud.fit.vutbr.cz
//=================================================================================================================
using itu.BL.DTOs.Workflow.Search;
using itu.Common.Enums;
using itu.DAL.Entities;
using OpenData_BL.DTOs.DataSet.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.BL.DTOs.Workflow
{
    public class OverviewWorkflowDTO
    {
        public SearchDTO SearchOptions { get; set; }
        public List<AllWorkflowDTO> AllWorkflow { get; set; }
    }
}
