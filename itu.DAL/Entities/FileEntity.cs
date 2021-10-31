﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;

namespace itu.DAL.Entities
{
    public class FileEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int Version { get; set; }
        public FileTypeEnum Type { get; set; }
        public int FileDataId { get; set; }
        public FileDataEntity FileData { get; set; }
        public int TaskId { get; set; }
        public TaskEntity Task { get; set; }
    }
}
