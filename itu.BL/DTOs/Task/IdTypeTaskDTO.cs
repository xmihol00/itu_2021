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
            return x.Id == y.Id;
        }

        public int GetHashCode(IdTypeTaskDTO obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
