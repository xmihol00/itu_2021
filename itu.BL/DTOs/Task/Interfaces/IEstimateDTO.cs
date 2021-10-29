using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;

namespace itu.BL.DTOs.Task.Interfaces
{
    public interface IEstimateDTO : IDetailTaskDTO
    {
        public double EstimatePrice { get; set; }
        public double MaxPrice { get; set; }
    }
}
