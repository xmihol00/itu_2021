using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.BL.DTOs.File;
using itu.BL.DTOs.Task.Interfaces;
using itu.Common.Enums;

namespace itu.BL.DTOs.Task
{
    public class TaskPostDTO
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public string DelayReason { get; set; }
    }
}
