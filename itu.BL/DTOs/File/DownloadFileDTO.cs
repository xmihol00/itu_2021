using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace itu.BL.DTOs.File
{
    public class DownloadFileDTO
    {
        public string Name { get; set; }
        public string MIME { get; set; }
        public byte[] Data { get; set; }
    }
}
