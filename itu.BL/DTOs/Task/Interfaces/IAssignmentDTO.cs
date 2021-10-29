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
        public double PriceGues { get; set; }
        public CurrencyEnum Currency { get; set; }
    }
}
