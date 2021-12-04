//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       Marek Fiala
// Kontakt:     xfiala60@stud.fit.vutbr.cz
//=================================================================================================================

using AutoMapper;
using itu.BL.DTOs.Agenda;
using itu.BL.DTOs.User;
using itu.BL.DTOs.Workflow;
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
 
            CreateMap<IGrouping<string, ModelWorkflowEntity>, WorkflowCountDTO>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Key))
                .ForMember(dst => dst.Count, opt => opt.MapFrom(src => src.Count()));

            CreateMap<AgendaEntity, AgendaDetailDTO>()
                .ForMember(dst => dst.AdministratorName, opt => opt.MapFrom(src => src.Administrator.FirstName + " " + src.Administrator.LastName))
                .ForMember(dst => dst.Models, opt => opt.MapFrom(src => src.AgendaModels.Select(x => x.Model)))
                .ForMember(dst => dst.Roles, opt => opt.MapFrom(src => src.AgendaRoles));
            
            CreateMap<AgendaRoleEntity, AgendaRoleDTO>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dst => dst.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                .ForMember(dst => dst.Role, opt => opt.MapFrom(src => src.Type));

            CreateMap<WorkflowEntity, AllWorkflowAgendaDTO>();

            CreateMap<UserEntity, AllUserDTO>()
                .ForMember(dst => dst.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));
            
            CreateMap<NewRoleDTO, AgendaRoleEntity>();

            CreateMap<ModelWorkflowEntity, AgendaModelDTO>();

            CreateMap<WorkflowEntity, AllWorkflowAgendaDTO>()
                .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.Tasks.First().UserId))
                .ForMember(dst => dst.UserName, opt => opt.MapFrom(src => src.Tasks.First().User.FirstName + " " + src.Tasks.First().User.LastName))
                .ForMember(dst => dst.TaskId, opt => opt.MapFrom(src => src.Tasks.First().Id))
                .ForMember(dst => dst.Priority, opt => opt.MapFrom(src => src.Tasks.First().Priority))
                .ForMember(dst => dst.End, opt => opt.MapFrom(src => src.Tasks.First().End))
                .ForMember(dst => dst.TaskType, opt => opt.MapFrom(src => src.Tasks.First().ToType()))
                .ForMember(dst => dst.TaskOrder, opt => opt.MapFrom(src => src.Tasks.First().Order))
                .ForMember(dst => dst.ModelId, opt => opt.MapFrom(src => src.ModelWorkflowId));
        }
    }
}
