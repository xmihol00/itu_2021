using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.DAL.Entities.Tasks
{
    public class EstimateEntity : TaskEntity 
    {
        public string EstimateId { get; set; }
        public double EstimatePrice { get; set; }
        public double MaxPrice { get; set; }
    }
}
