using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;

namespace itu.BL.DTOs.Task.Interfaces
{
    public interface IArchivationDTO : IDetailTaskDTO
    {
        public LocationEnum Location { get; set; } 
        public int Number { get; set; }
        public DateTime Cancallation { get; set; }
    }
}
