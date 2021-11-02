using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.DAL.Entities.Tasks.Interfaces
{
    public interface IAssessmentEntity : ITaskEntity
    {
        public string Conclusion { get; set; }
    }
}
