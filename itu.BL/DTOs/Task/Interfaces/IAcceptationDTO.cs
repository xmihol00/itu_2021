using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;

namespace itu.BL.DTOs.Task.Interfaces
{
    public interface IAcceptationDTO : IDetailTaskDTO
    {
        public string Reason { get; set; }
        public bool Accepted { get; set; }
    }
}
