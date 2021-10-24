using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.BL.DTOs.Account
{
    public class RegistrationDTO
    {
        public string Name { get; set; }
        public string Surrname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ReturnURL { get; set; }
    }
}
