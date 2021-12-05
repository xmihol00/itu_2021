//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       Vítek Hnatovskyj
// Kontakt:     xhnato00@stud.fit.vutbr.cz
//=================================================================================================================

using AutoMapper;
using itu.BL.DTOs.Agenda;
using itu.BL.DTOs.Task;
using itu.BL.DTOs.Workflow;
using itu.DAL.Entities;
using itu.DAL.Entities.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.BL.Profiles
{
    public class WorkflowProfile : Profile
    {
        public WorkflowProfile()
        {
            CreateMap<WorkflowEntity, AllWorkflow>();
            CreateMap<WorkflowEntity, AllWorkflowDTO>()
                .ForMember(dst => dst.Agenda, opt => opt.MapFrom(src => src.Agenda))
                .ForMember(dst => dst.Tasks, opt => opt.MapFrom(src => src.Tasks));

            CreateMap<WorkflowEntity, DetailWorkflowDTO>();
            CreateMap<ModelWorkflowEntity, IdNameModelDTO>();
            CreateMap<WorkflowAgendaOverviewDTO, IdNameAgendaDTO>();
            CreateMap<WorkflowTaskOverviewDTO, IdTypeTaskDTO>();

            CreateMap<AgendaEntity, WorkflowAgendaOverviewDTO>();
            CreateMap<AgendaEntity, IdNameAgendaDTO>();
            CreateMap<NoteEntity, AllNoteDTO>();
        }
    }
}
