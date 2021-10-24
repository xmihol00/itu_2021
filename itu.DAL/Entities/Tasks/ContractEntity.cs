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
        public string ContractId { get; set; }
        public double FinalPrice { get; set; }
        public string PriceChangeReason { get; set; }
        public ContractTypeEnum Type { get; set; }
    }
}
