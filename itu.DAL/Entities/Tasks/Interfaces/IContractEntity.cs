using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;

namespace itu.DAL.Entities.Tasks.Interfaces
{
    public interface IContractEntity : ITaskEntity
    {
        public double FinalPrice { get; set; }
        public string PriceChangeReason { get; set; }
        public ContractTypeEnum ContractType { get; set; }
        public CurrencyEnum Currency { get; set; }
    }
}
