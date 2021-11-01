using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace itu.BL.DTOs.File
{
    public class VersionChangeDTO
    {
        public int FileId { get; set; }
        public int Version { get; set; }
    }
}
