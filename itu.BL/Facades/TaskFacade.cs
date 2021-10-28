using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using itu.BL.DTOs.Task;
using itu.DAL.Repositories;

namespace itu.BL.Facades
{
    public class TaskFacade
    {
        private readonly TaskRepository _repository;
        private readonly IMapper _mapper;

        public TaskFacade(TaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AllTaskDTO>> AllOfUser(int userId)
        {
            return _mapper.Map<List<AllTaskDTO>>(await _repository.AllOfUser(userId));
        }

        public async Task<DetailTaskDTO> Detail(int userId, int taskId)
        {
            return _mapper.Map<DetailTaskDTO>(await _repository.Detail(userId, taskId));
        }
    }
}
