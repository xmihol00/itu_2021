using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;

namespace itu.BL.DTOs.Agenda
{
    public class AgendaRoleDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public TaskTypeEnum Role { get; set; }
    }
}
