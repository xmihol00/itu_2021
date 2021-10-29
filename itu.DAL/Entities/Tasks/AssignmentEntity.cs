using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;

namespace itu.DAL.Entities.Tasks
{
    public class AssignmentEntity : TaskEntity
    {
        public string Reason { get; set; }
        public double PriceGues { get; set; }
        public CurrencyEnum Currency { get; set; }
    }
}
