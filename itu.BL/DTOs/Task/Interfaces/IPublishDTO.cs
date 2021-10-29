using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;

namespace itu.BL.DTOs.Task.Interfaces
{
    public interface IPublishDTO : IDetailTaskDTO
    {
        public DateTime PublishStart { get; set; }
        public DateTime PublishEnd { get; set; }
    }
}
