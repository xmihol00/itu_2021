using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.BL.DTOs.User;
using itu.Common.Enums;

namespace itu.BL.DTOs.Agenda
{
    public class AgendaDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<AgendaRoleDTO> Roles { get; set; }
        public int AdministratorId { get; set; }
        public string AdministratorName { get; set; }
        public List<AllWorkflowAgendaDTO> Workflows { get; set; }
        public List<AllUserDTO> Users { get; set; }
    }
}
