using AutoMapper;
using itu.BL.DTOs.Agenda;
using itu.BL.DTOs.Workflow;
using itu.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.BL.Profiles
{
    public class AgendaProfile : Profile
    {
        public AgendaProfile()
        {
            CreateMap<AgendaEntity, WorkflowAgendaOverviewDTO>();
            CreateMap<AgendaEntity, IdNameAgendaDTO>();
        }
    }
}
