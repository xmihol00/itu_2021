//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       Marek Fiala
// Kontakt:     xfiala60@stud.fit.vutbr.cz
//=================================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.DAL.Entities
{
    public class AgendaEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Creation { get; set; }
        public List<WorkflowEntity> Workflows { get; set; }
        public List<AgendaRoleEntity> AgendaRoles { get; set; }
        public int AdministratorId { get; set; }
        public UserEntity Administrator { get; set; }
        public List<AgendaModelEntity> AgendaModels { get; set; }
    }
}
