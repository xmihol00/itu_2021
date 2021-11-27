using AutoMapper;
using itu.BL.DTOs.Agenda;
using itu.BL.DTOs.User;
using itu.DAL.Entities;
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
        private readonly UserRepository _userRepository;
        private readonly AgendaRoleRepository _agendaRoleRepository;
        private readonly IMapper _mapper;

        public AgendaFacade(AgendaRepository repository, UserRepository userRepository, AgendaRoleRepository agendaRoleRepository, 
                            IMapper mapper)
        {
            _repository = repository;
            _userRepository = userRepository;
            _agendaRoleRepository = agendaRoleRepository;
            _mapper = mapper;
        }

        public async Task<List<AllAgendaDTO>> All()
        {
            return _mapper.Map<List<AllAgendaDTO>>(await _repository.All());
        }

        public async Task<AgendaDetailDTO> Detail(int id)
        {
            var agenda = _mapper.Map<AgendaDetailDTO>(await _repository.Detail(id));
            agenda.Users = _mapper.Map<List<AllUserDTO>>(await _userRepository.All());
            return agenda;
        }

        public async Task<(List<AgendaRoleDTO>, List<AllUserDTO>)> EditRole(EditedRoleDTO edited)
        {
            var role = await _agendaRoleRepository.Detail(edited.Id);
            role.UserId = edited.UserId;
            await _agendaRoleRepository.Save();
            var roles = _mapper.Map<List<AgendaRoleDTO>>(await _agendaRoleRepository.AllOfAgenda(role.AgendaId));
            var users = _mapper.Map<List<AllUserDTO>>(await _userRepository.All());
            return (roles, users);
        }

        public async Task EditAdmin(EditAdminDTO data)
        {
            var agenda = await _repository.DetailForEdit(data.Id);
            agenda.AdministratorId = data.AdminId;
            await _repository.Save();
        }

        public async Task EditData(EditDataDTO data)
        {
            var agenda = await _repository.DetailForEdit(data.Id);
            agenda.Name = data.Name;
            agenda.Description = data.Description;
            await _repository.Save();
        }

        public async Task<(List<AgendaRoleDTO>, List<AllUserDTO>)> RemoveRole(int id)
        {
            var role = await _agendaRoleRepository.Detail(id);
            _agendaRoleRepository.Delete(role);
            await _agendaRoleRepository.Save();
            var roles = _mapper.Map<List<AgendaRoleDTO>>(await _agendaRoleRepository.AllOfAgenda(role.AgendaId));
            var users = _mapper.Map<List<AllUserDTO>>(await _userRepository.All());
            return (roles, users);
        }

        public async Task<(List<AgendaRoleDTO>, List<AllUserDTO>)> AddRole(NewRoleDTO role)
        {
            var roleEntity = _mapper.Map<AgendaRoleEntity>(role);
            await _agendaRoleRepository.Create(roleEntity);
            await _agendaRoleRepository.Save();
            var roles = _mapper.Map<List<AgendaRoleDTO>>(await _agendaRoleRepository.AllOfAgenda(role.AgendaId));
            var users = _mapper.Map<List<AllUserDTO>>(await _userRepository.All());
            return (roles, users);
        }
    }
}
