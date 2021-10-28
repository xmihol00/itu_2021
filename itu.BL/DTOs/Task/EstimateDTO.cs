using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.BL.DTOs.Task.Interfaces;
using itu.Common.Enums;

namespace itu.BL.DTOs.Task
{
    public class EstimateDTO : DetailTaskDTO, IEstimateDTO
    {
        public string EstimateId { get; set; }
        public double EstimatePrice { get; set; }
        public double MaxPrice { get; set; }
    }
}
