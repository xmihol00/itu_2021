using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.Common.Enums
{
    public enum TaskTypeEnum
    {
        Assignment,
        Acceptation,
        Assessment,
        Estimate,
        Contract,
        Publish,
        Archivation,
    }

    public static class TaskType
    {
        public static string ToLabel(this TaskTypeEnum value)
        {
            switch (value)
            {
                case TaskTypeEnum.Acceptation:
                    return "Schválení";
                
                case TaskTypeEnum.Assessment:
                    return "Posouzení";
                
                case TaskTypeEnum.Archivation:
                    return "Archivace";
                
                case TaskTypeEnum.Assignment:
                    return "Zadání";
                
                case TaskTypeEnum.Contract:
                    return "Tvorba smlouvy";
                
                case TaskTypeEnum.Estimate:
                    return "Odhad ceny";
                
                case TaskTypeEnum.Publish:
                    return "Zveřejnění";
                
                default:
                    return "";
            }
        }
    }
}
