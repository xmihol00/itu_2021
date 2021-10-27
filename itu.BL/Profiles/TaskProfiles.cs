using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using itu.BL.DTOs.Task;
using itu.DAL.Entities;

namespace itu.BL.Profiles
{
    public class TaskProfiles : Profile
    {
        public TaskProfiles()
        {
            CreateMap<TaskEntity, AllTaskDTO>()
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => TaskEntity.ToLabel(src.GetType())));
        }
    }
}
