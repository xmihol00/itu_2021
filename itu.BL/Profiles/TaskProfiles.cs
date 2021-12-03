//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       David Mihola
// Kontakt:     xmihol00@stud.fit.vutbr.cz
//=================================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using itu.BL.DTOs.Task;
using itu.BL.DTOs.Task.Interfaces;
using itu.BL.DTOs.Workflow;
using itu.Common.Enums;
using itu.DAL.Entities;
using itu.DAL.Entities.Tasks;

namespace itu.BL.Profiles
{
    public class TaskProfiles : Profile
    {
        public TaskProfiles()
        {
            CreateMap<TaskEntity, AcceptationEntity>()
                .ForMember(dst => dst.WorkflowId, opt => opt.MapFrom(src => src.WorkflowId))
                .ForMember(dst => dst.Note, opt => opt.Ignore())
                .ForMember(dst => dst.DelayReason, opt => opt.Ignore())
                .ForMember(dst => dst.Order, opt => opt.MapFrom(src => src.Order + 1))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => 0))
                .ForMember(dst => dst.Start, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dst => dst.Priority, opt => opt.MapFrom(src => PriorityEnum.Medium))
                .ForMember(dst => dst.Active, opt => opt.MapFrom(src => true))
                .ForMember(dst => dst.Accepted, opt => opt.MapFrom(src => true));

            CreateMap<TaskEntity, AssignmentEntity>()
                .ForMember(dst => dst.WorkflowId, opt => opt.MapFrom(src => src.WorkflowId))
                .ForMember(dst => dst.Note, opt => opt.Ignore())
                .ForMember(dst => dst.DelayReason, opt => opt.Ignore())
                .ForMember(dst => dst.Order, opt => opt.MapFrom(src => src.Order + 1))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => 0))
                .ForMember(dst => dst.Start, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dst => dst.Priority, opt => opt.MapFrom(src => PriorityEnum.Medium))
                .ForMember(dst => dst.Active, opt => opt.MapFrom(src => true));

            CreateMap<TaskEntity, AssessmentEntity>()
                .ForMember(dst => dst.WorkflowId, opt => opt.MapFrom(src => src.WorkflowId))
                .ForMember(dst => dst.Note, opt => opt.Ignore())
                .ForMember(dst => dst.DelayReason, opt => opt.Ignore())
                .ForMember(dst => dst.Order, opt => opt.MapFrom(src => src.Order + 1))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => 0))
                .ForMember(dst => dst.Start, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dst => dst.Priority, opt => opt.MapFrom(src => PriorityEnum.Medium))
                .ForMember(dst => dst.Active, opt => opt.MapFrom(src => true));

            CreateMap<TaskEntity, ArchivationEntity>()
                .ForMember(dst => dst.WorkflowId, opt => opt.MapFrom(src => src.WorkflowId))
                .ForMember(dst => dst.Note, opt => opt.Ignore())
                .ForMember(dst => dst.DelayReason, opt => opt.Ignore())
                .ForMember(dst => dst.Order, opt => opt.MapFrom(src => src.Order + 1))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => 0))
                .ForMember(dst => dst.Start, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dst => dst.Priority, opt => opt.MapFrom(src => PriorityEnum.Medium))
                .ForMember(dst => dst.Active, opt => opt.MapFrom(src => true));

            CreateMap<TaskEntity, PublishEntity>()
                .ForMember(dst => dst.WorkflowId, opt => opt.MapFrom(src => src.WorkflowId))
                .ForMember(dst => dst.Note, opt => opt.Ignore())
                .ForMember(dst => dst.DelayReason, opt => opt.Ignore())
                .ForMember(dst => dst.Order, opt => opt.MapFrom(src => src.Order + 1))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => 0))
                .ForMember(dst => dst.Start, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dst => dst.Priority, opt => opt.MapFrom(src => PriorityEnum.Medium))
                .ForMember(dst => dst.Active, opt => opt.MapFrom(src => true));

            CreateMap<TaskEntity, ContractEntity>()
                .ForMember(dst => dst.WorkflowId, opt => opt.MapFrom(src => src.WorkflowId))
                .ForMember(dst => dst.Note, opt => opt.Ignore())
                .ForMember(dst => dst.DelayReason, opt => opt.Ignore())
                .ForMember(dst => dst.Order, opt => opt.MapFrom(src => src.Order + 1))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => 0))
                .ForMember(dst => dst.Start, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dst => dst.Priority, opt => opt.MapFrom(src => PriorityEnum.Medium))
                .ForMember(dst => dst.Active, opt => opt.MapFrom(src => true));

            CreateMap<TaskEntity, EstimateEntity>()
                .ForMember(dst => dst.WorkflowId, opt => opt.MapFrom(src => src.WorkflowId))
                .ForMember(dst => dst.Note, opt => opt.Ignore())
                .ForMember(dst => dst.DelayReason, opt => opt.Ignore())
                .ForMember(dst => dst.Order, opt => opt.MapFrom(src => src.Order + 1))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => 0))
                .ForMember(dst => dst.Start, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dst => dst.Priority, opt => opt.MapFrom(src => PriorityEnum.Medium))
                .ForMember(dst => dst.Active, opt => opt.MapFrom(src => true));

            CreateMap<TaskEntity, AllTaskDTO>()
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.ToLabel()))
                .ForMember(dst => dst.AgendaId, opt => opt.MapFrom(src => src.Workflow.AgendaId))
                .ForMember(dst => dst.WorkflowName, opt => opt.MapFrom(src => src.Workflow.Name));
            
            CreateMap<AssignmentEntity, AssignmentDTO>()
                .ForMember(dst => dst.WorkflowName, opt => opt.MapFrom(src => src.Workflow.Name))
                .ForMember(dst => dst.AgendaName, opt => opt.MapFrom(src => src.Workflow.Agenda.Name))
                .ForMember(dst => dst.AgendaId, opt => opt.MapFrom(src => src.Workflow.AgendaId))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Workflow.Description))
                .ForMember(dst => dst.Files, opt => opt.MapFrom(src => src.Workflow.Files));
            
            CreateMap<AcceptationEntity, AcceptationDTO>()
                .ForMember(dst => dst.WorkflowName, opt => opt.MapFrom(src => src.Workflow.Name))
                .ForMember(dst => dst.AgendaName, opt => opt.MapFrom(src => src.Workflow.Agenda.Name))
                .ForMember(dst => dst.AgendaId, opt => opt.MapFrom(src => src.Workflow.AgendaId))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Workflow.Description))
                .ForMember(dst => dst.Files, opt => opt.MapFrom(src => src.Workflow.Files));
            
            CreateMap<AssessmentEntity, AssessmentDTO>()
                .ForMember(dst => dst.WorkflowName, opt => opt.MapFrom(src => src.Workflow.Name))
                .ForMember(dst => dst.AgendaName, opt => opt.MapFrom(src => src.Workflow.Agenda.Name))
                .ForMember(dst => dst.AgendaId, opt => opt.MapFrom(src => src.Workflow.AgendaId))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Workflow.Description))
                .ForMember(dst => dst.Files, opt => opt.MapFrom(src => src.Workflow.Files));

            CreateMap<ArchivationEntity, ArchivationDTO>()
                .ForMember(dst => dst.WorkflowName, opt => opt.MapFrom(src => src.Workflow.Name))
                .ForMember(dst => dst.AgendaName, opt => opt.MapFrom(src => src.Workflow.Agenda.Name))
                .ForMember(dst => dst.AgendaId, opt => opt.MapFrom(src => src.Workflow.AgendaId))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Workflow.Description))
                .ForMember(dst => dst.Files, opt => opt.MapFrom(src => src.Workflow.Files));

            CreateMap<ContractEntity, ContractDTO>()
                .ForMember(dst => dst.WorkflowName, opt => opt.MapFrom(src => src.Workflow.Name))
                .ForMember(dst => dst.AgendaName, opt => opt.MapFrom(src => src.Workflow.Agenda.Name))
                .ForMember(dst => dst.AgendaId, opt => opt.MapFrom(src => src.Workflow.AgendaId))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Workflow.Description))
                .ForMember(dst => dst.Files, opt => opt.MapFrom(src => src.Workflow.Files));

            CreateMap<EstimateEntity, EstimateDTO>()
                .ForMember(dst => dst.WorkflowName, opt => opt.MapFrom(src => src.Workflow.Name))
                .ForMember(dst => dst.AgendaName, opt => opt.MapFrom(src => src.Workflow.Agenda.Name))
                .ForMember(dst => dst.AgendaId, opt => opt.MapFrom(src => src.Workflow.AgendaId))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Workflow.Description))
                .ForMember(dst => dst.Files, opt => opt.MapFrom(src => src.Workflow.Files));

            CreateMap<PublishEntity, PublishDTO>()
                .ForMember(dst => dst.WorkflowName, opt => opt.MapFrom(src => src.Workflow.Name))
                .ForMember(dst => dst.AgendaName, opt => opt.MapFrom(src => src.Workflow.Agenda.Name))
                .ForMember(dst => dst.AgendaId, opt => opt.MapFrom(src => src.Workflow.AgendaId))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Workflow.Description))
                .ForMember(dst => dst.Files, opt => opt.MapFrom(src => src.Workflow.Files));

            CreateMap<TaskEntity, DetailTaskDTO>()
                .Include<AssignmentEntity, AssignmentDTO>()
                .Include<AcceptationEntity, AcceptationDTO>()
                .Include<AssessmentEntity, AssessmentDTO>()
                .Include<ArchivationEntity, ArchivationDTO>()
                .Include<ContractEntity, ContractDTO>()
                .Include<EstimateEntity, EstimateDTO>()
                .Include<PublishEntity, PublishDTO>()
                .ForMember(dst => dst.WorkflowName, opt => opt.MapFrom(src => src.Workflow.Name))
                .ForMember(dst => dst.AgendaName, opt => opt.MapFrom(src => src.Workflow.Agenda.Name))
                .ForMember(dst => dst.AgendaId, opt => opt.MapFrom(src => src.Workflow.AgendaId))
                .ForMember(dst => dst.Files, opt => opt.MapFrom(src => src.Workflow.Files));

            CreateMap<TaskEntity, WorkflowTaskOverviewDTO>()
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.ToLabel()));
            CreateMap<TaskEntity, IdTypeTaskDTO>();
        }
    }
}
