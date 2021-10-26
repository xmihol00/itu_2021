using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.DAL.Entities.Tasks
{
    public class AssignmentEntity : TaskEntity
    {
        public string FormNumber { get; set; }
        public string Reason { get; set; }
        public string OrderName { get; set; }
        public double Price { get; set; }
    }
}
