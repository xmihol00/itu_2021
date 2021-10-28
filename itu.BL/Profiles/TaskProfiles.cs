using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using itu.BL.DTOs.Task;
using itu.BL.DTOs.Task.Interfaces;
using itu.DAL.Entities;
using itu.DAL.Entities.Tasks;

namespace itu.BL.Profiles
{
    public class TaskProfiles : Profile
    {
        public TaskProfiles()
        {
            CreateMap<TaskEntity, AllTaskDTO>()
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => TaskEntity.ToLabel(src.GetType())))
                .ForMember(dst => dst.AgendaId, opt => opt.MapFrom(src => src.Workflow.AgendaId))
                .ForMember(dst => dst.WorkflowName, opt => opt.MapFrom(src => src.Workflow.Name));
            
            CreateMap<AssignmentEntity, AssignmentDTO>()
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => TaskEntity.ToLabel(src.GetType())));
            
            CreateMap<AcceptationEntity, AcceptationDTO>()
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => TaskEntity.ToLabel(src.GetType())));
            
            CreateMap<AssessmentEntity, AssesmentDTO>()
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => TaskEntity.ToLabel(src.GetType())));

            CreateMap<ArchivationEntity, ArchivationDTO>()
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => TaskEntity.ToLabel(src.GetType())));

            CreateMap<ContractEntity, ContractDTO>()
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => TaskEntity.ToLabel(src.GetType())));

            CreateMap<EstimateEntity, EstimateDTO>()
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => TaskEntity.ToLabel(src.GetType())));

            CreateMap<PublishEntity, PublishDTO>()
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => TaskEntity.ToLabel(src.GetType())));

            CreateMap<TaskEntity, DetailTaskDTO>()
                .Include<AssignmentEntity, AssignmentDTO>()
                .Include<AcceptationEntity, AcceptationDTO>()
                .Include<AssessmentEntity, AssesmentDTO>()
                .Include<ArchivationEntity, ArchivationDTO>()
                .Include<ContractEntity, ContractDTO>()
                .Include<EstimateEntity, EstimateDTO>()
                .Include<PublishEntity, PublishDTO>()
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => TaskEntity.ToLabel(src.GetType())));
        }
    }
}
