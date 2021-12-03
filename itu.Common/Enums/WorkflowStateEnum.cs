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
                    return "Dokonèeno";

                case WorkflowStateEnum.Canceled:
                    return "Zrušeno";

                default:
                    return "";
            }
        }
    }
}
