using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;

namespace itu.DAL.Entities.Tasks
{
    public class ContractEntity : TaskEntity
    {
        public double FinalPrice { get; set; }
        public string PriceChangeReason { get; set; }
        public ContractTypeEnum ContractType { get; set; }
    }
}
