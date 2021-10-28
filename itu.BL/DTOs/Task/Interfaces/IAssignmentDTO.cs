using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;

namespace itu.BL.DTOs.Task.Interfaces
{
    public interface IAssignmentDTO : IDetailTaskDTO
    {
        public string FormNumber { get; set; }
        public string Reason { get; set; }
        public string OrderName { get; set; }
        public double Price { get; set; }
    }
}
