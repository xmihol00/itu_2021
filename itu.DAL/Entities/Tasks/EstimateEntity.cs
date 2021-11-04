using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;
using itu.DAL.Entities.Tasks.Interfaces;

namespace itu.DAL.Entities.Tasks
{
    public class EstimateEntity : TaskEntity, IEstimateEntity
    {
        public double EstimatePrice { get; set; }
        public double MaxPrice { get; set; }
        public CurrencyEnum Currency { get; set; }
    }
}
