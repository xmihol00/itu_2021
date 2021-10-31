using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace itu.BL.DTOs.File
{
    public class FileUploadDTO
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public IFormFile File { get; set; }
    }
}
