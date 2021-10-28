using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.BL.DTOs.Task.Interfaces;
using itu.Common.Enums;

namespace itu.BL.DTOs.Task
{
    public class ArchivationDTO : DetailTaskDTO, IArchivationDTO
    {
        public LocationEnum Location { get; set; } 
        public int Number { get; set; }
        public DateTime Cancallation { get; set; }
    }
}
