using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.BL.DTOs.Task.Interfaces;
using itu.Common.Enums;

namespace itu.BL.DTOs.Task
{
    public class AcceptationDTO : DetailTaskDTO, IAcceptationDTO
    {
        public string Reason { get; set; }
        public bool Accepted { get; set; }
    }
}
