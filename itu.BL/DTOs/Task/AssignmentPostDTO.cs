using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.BL.DTOs.File;
using itu.BL.DTOs.Task.Interfaces;
using itu.Common.Enums;

namespace itu.BL.DTOs.Task
{
    public class AssignmentPostDTO : TaskPostDTO
    {
        public string Benefit { get; set; }
        public double PriceGues { get; set; }
        public CurrencyEnum Currency { get; set; }
    }
}
