using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.DAL.Entities.Tasks
{
    public class PublishEntity : TaskEntity
    {
        public DateTime PublishStart { get; set; }
        public DateTime PublishEnd { get; set; }
    }
}
