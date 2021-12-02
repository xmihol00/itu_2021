using itu.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.BL.DTOs.Task
{
    public class IdTypeTaskDTO
    {
        public int Id { get; set; }
        public FileTypeEnum FileType { get; set; }
    }
    class IdTypeTaskDTOEqualityComparer : IEqualityComparer<IdTypeTaskDTO>
    {
        public bool Equals(IdTypeTaskDTO x, IdTypeTaskDTO y)
        {
            // Two items are equal if their keys are equal.
            return x.Id == y.Id;
        }

        public int GetHashCode(IdTypeTaskDTO obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
