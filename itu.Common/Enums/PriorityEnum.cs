using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.Common.Enums
{
    public enum PriorityEnum
    {
        Low,
        Medium,
        High,
        Urgent,
    }

    public static class Priority
    {
        public static string ToLabel(this PriorityEnum value)
        {
            switch (value)
            {
                case PriorityEnum.Low:
                    return "nízká";
                
                case PriorityEnum.Medium:
                    return "střední";
                
                case PriorityEnum.High:
                    return "vysoká";

                case PriorityEnum.Urgent:
                    return "urgentní";
                
                default:
                    return "";
            }
        }
    }
}
