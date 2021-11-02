﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;
using itu.DAL.Entities.Tasks.Interfaces;

namespace itu.DAL.Entities.Tasks
{
    public class ArchivationEntity : TaskEntity, IArchivationEntity
    {
        public LocationEnum Location { get; set; } 
        public int Number { get; set; }
        public DateTime Cancallation { get; set; }
    }
}
