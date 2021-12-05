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

namespace itu.Common.Enums
{
    public enum WorkflowStateEnum
    {
        Active,
        Stopped,
        Finished,
        Canceled,
    }

    public static class WorkflowState
    {
        public static string ToLabel(this WorkflowStateEnum value)
        {
            switch (value)
            {
                case WorkflowStateEnum.Active:
                    return "Aktivní";

                case WorkflowStateEnum.Stopped:
                    return "Pozastaveno";

                case WorkflowStateEnum.Finished:
                    return "Dokončeno";

                case WorkflowStateEnum.Canceled:
                    return "Zrušeno";

                default:
                    return "";
            }
        }
    }
}
