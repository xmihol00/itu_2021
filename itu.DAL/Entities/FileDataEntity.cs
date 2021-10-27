using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.DAL.Entities
{
    public class FileDataEntity
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public FileEntity File { get; set; }
    }
}
