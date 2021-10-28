using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;

namespace itu.BL.DTOs.Task.Interfaces
{
    public interface IAssesmentDTO : IDetailTaskDTO
    {
        public string AssessmentId { get; set; }
        public string Conclusion { get; set; }
    }
}
