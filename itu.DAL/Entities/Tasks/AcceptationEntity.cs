using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.DAL.Entities.Tasks
{
    public class AcceptationEntity : TaskEntity
    {
        public string Reason { get; set; }
        public bool Accepted { get; set; }
    }
}
