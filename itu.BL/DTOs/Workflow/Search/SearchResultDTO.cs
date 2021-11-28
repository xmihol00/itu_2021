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

namespace OpenData_BL.DTOs.DataSet.Search
{
    public class SearchResultDTO
    {
        public string ResultMessage { get; set; }
        public string FiltersHTML { get; set; }
        public string WorkflowsHTML { get; set; }
    }
}
