using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.Common.Enums
{
    public enum FileTypeEnum
    {
        Assignment,
        Assessment,
        Acceptation,
        Estimate,
        Publication,
        Contract,
        Archivation,
    }

    public static class FileType
    {
        public static string ToLabel(this FileTypeEnum value)
        {
            switch (value)
            {
                case FileTypeEnum.Assignment:
                    return "zadání";
                
                case FileTypeEnum.Acceptation:
                    return "schválení";

                case FileTypeEnum.Assessment:
                    return "posouzení";
                
                case FileTypeEnum.Estimate:
                    return "odhad";
                
                case FileTypeEnum.Publication:
                    return "zveřejnění";
                
                case FileTypeEnum.Contract:
                    return "smouva";
                
                case FileTypeEnum.Archivation:
                    return "archivace";
                
                default:
                    return "";
            }
        }
    }
}
