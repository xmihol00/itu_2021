﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.DAL.Entities.Tasks.Interfaces;

namespace itu.DAL.Entities.Tasks
{
    public class PublishEntity : TaskEntity, IPublishEntity
    {
        public DateTime PublishStart { get; set; }
        public DateTime PublishEnd { get; set; }
    }
}
