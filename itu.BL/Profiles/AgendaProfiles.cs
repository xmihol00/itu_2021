using AutoMapper;
using itu.BL.DTOs.Agenda;
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
            CreateMap<AgendaEntity, AllAgendaDTO>();
        }
    }
}
