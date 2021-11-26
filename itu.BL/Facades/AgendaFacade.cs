using AutoMapper;
using itu.BL.DTOs.Agenda;
using itu.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.BL.Facades
{
    public class AgendaFacade
    {
        private readonly AgendaRepository _repository;
        private readonly IMapper _mapper;

        public AgendaFacade(AgendaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AllAgendaDTO>> All()
        {
            return _mapper.Map<List<AllAgendaDTO>>(await _repository.All());
        }

        public async Task<AgendaDetailDTO> Detail(int id)
        {
            return _mapper.Map<AgendaDetailDTO>(await _repository.Detail(id));
        }
    }
}
