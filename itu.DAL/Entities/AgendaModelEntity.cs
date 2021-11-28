using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;

namespace itu.DAL.Entities
{
    public class AgendaModelEntity
    {
        public int AgendaId { get; set; }
        public AgendaEntity Agenda { get; set; }
        public int ModelId { get; set; }
        public ModelWorkflowEntity Model { get; set; }
    }
}
