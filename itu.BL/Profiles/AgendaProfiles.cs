using AutoMapper;
using itu.BL.DTOs.Agenda;
using itu.Common.Enums;
using itu.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.BL.Profiles
{
    public class AgendaProfiles : Profile
    {
        public AgendaProfiles()
        {
            CreateMap<AgendaEntity, AllAgendaDTO>()
                .ForMember(dst => dst.Workflows, opt => opt.MapFrom(src => src.Workflows.Where(x => x.State == WorkflowStateEnum.Active)
                                                                                        .Select(x => x.ModelWorkflow).GroupBy(x => x.Name)))
                .ForMember(dst => dst.UserCount, opt => opt.MapFrom(src => src.AgendaRoles.Where(x => x.UserId != 0).Select(x => x.UserId).Distinct().Count()))
                .ForMember(dst => dst.NotFilledRoleCount, opt => opt.MapFrom(src => src.AgendaRoles.Where(x => x.UserId == 0).Select(x => x.UserId).Count()));
 
            CreateMap<IGrouping<string, ModelWorkflowEntity>, AllWorkflowAgendaDTO>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Key))
                .ForMember(dst => dst.Count, opt => opt.MapFrom(src => src.Count()));
        }
    }
}
