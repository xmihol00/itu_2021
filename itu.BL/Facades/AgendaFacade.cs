//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       Marek Fiala
// Kontakt:     xfiala60@stud.fit.vutbr.cz
//=================================================================================================================

using AutoMapper;
using itu.BL.DTOs.Agenda;
using itu.BL.DTOs.User;
using itu.Common.Enums;
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
        private readonly AgendaModelRepository _agendaModelRepository;
        private readonly ModelWorkflowRepository _modelWorkflowRespository; 
        private readonly WorkflowRepository _workflowRespository; 
        private readonly TaskRepository _taskRespository;
        private readonly NoteRepository _noteRespository;
        private readonly IMapper _mapper;

        public AgendaFacade(AgendaRepository repository, UserRepository userRepository, AgendaRoleRepository agendaRoleRepository, 
                            AgendaModelRepository agendaModelRepository, ModelWorkflowRepository modelWorkflowRespository, 
                            WorkflowRepository workflowRespository, TaskRepository taskRespository, NoteRepository noteRespository, 
                            IMapper mapper)
        {
            _repository = repository;
            _userRepository = userRepository;
            _agendaRoleRepository = agendaRoleRepository;
            _agendaModelRepository = agendaModelRepository;
            _modelWorkflowRespository = modelWorkflowRespository;
            _workflowRespository = workflowRespository;
            _taskRespository = taskRespository;
            _noteRespository = noteRespository;
            _mapper = mapper;
        }

        public async Task Create(AgendaCreateDTO model, int userId)
        {
            var agenda = new AgendaEntity()
            {
                Name = model.Name,
                Description = model.Description,
                AdministratorId = userId
            };
            await _repository.Create(agenda);
            await _repository.Save();
        }

        public async Task<List<AllAgendaDTO>> All()
        {
            return _mapper.Map<List<AllAgendaDTO>>(await _repository.All());
        }

        public async Task<AgendaDetailDTO> Detail(int id)
        {
            var detail = await _repository.Detail(id);
            detail.Workflows = detail.Workflows.Where(x => x.State == WorkflowStateEnum.Active || x.State == WorkflowStateEnum.Stopped).ToList();
            foreach(var wf in detail.Workflows)
            {
                wf.Tasks = wf.Tasks.Where(x => x.Active).ToList();
            }
            var agenda = _mapper.Map<AgendaDetailDTO>(detail);
            agenda.Users = _mapper.Map<List<AllUserDTO>>(await _userRepository.All());
            agenda.Runable = agenda.Roles.All(x => x.UserId != 0);
            return agenda;
        }

        public async Task<AgendaDetailDTO> EditRole(EditedRoleDTO edited, int userId)
        {
            var role = await _agendaRoleRepository.Detail(edited.Id);
            role.UserId = edited.UserId;
            await _agendaRoleRepository.Save();
            
            return await Detail(role.AgendaId);
        }

        public async Task RemoveModel(int modelId, int agedaId)
        {
            var model = await _agendaModelRepository.Detail(modelId, agedaId);
            _agendaModelRepository.Delete(model);
            await _agendaModelRepository.Save();
        }

        public (int modelId, int active, int width, int height) ModelDetail(int id, int order = 0)
        {
            return (id, order, 660, 560);
        }

        public async Task RunWorkflow(RunWorkflowDTO dto)
        {
            var transaction = await _repository.CreateTransaction();
            int days = 0;
            var model = await _modelWorkflowRespository.ModelWithRoles(dto.ModelId);
            foreach (var diff in model.WorkflowTasks)
            {
                days += diff.ModelTask.Difficulty;
            }

            var workflow = new WorkflowEntity()
            {
                AgendaId = dto.AgendaId,
                Creation = DateTime.Now,
                Description = dto.Description,
                Name = dto.Name,
                ModelWorkflowId = dto.ModelId,
                State = WorkflowStateEnum.Active,
                ExpectedEnd = DateTime.Now.AddDays(days),
            };

            await _workflowRespository.Create(workflow);
            await _workflowRespository.Save();

            var firtModel = model.WorkflowTasks.OrderBy(x => x.Order).Select(x => x.ModelTask).First();
            var userId = await _repository.NextUserId(dto.AgendaId, firtModel.Type);

            var task = TaskEntity.Factory(firtModel.Type);
            task.Order = 1;
            task.Start = DateTime.Now;
            task.End = DateTime.Now.AddDays(firtModel.Difficulty);
            task.UserId = userId.Value;
            task.WorkflowId = workflow.Id;
            task.Priority = PriorityEnum.Medium;
            task.Active = true;
            await _taskRespository.Create(task);
            await _taskRespository.Save();

            transaction.Commit();
        }

        public async Task<AgendaDetailDTO> ChangeWorfklowState(WorkflowStateDTO state)
        {
            var workflow = await _workflowRespository.GetForEdit(state.WorkflowId);
            var note = new NoteEntity();
            note.Before = workflow.State;
            workflow.State = state.State;
            note.After = workflow.State;
            note.WorkflowId = workflow.Id;
            note.Note = state.Note;
            note.Created = DateTime.Now;
            await _noteRespository.Create(note);
            await _repository.Save();

            return _mapper.Map<AgendaDetailDTO>(await _repository.Detail(state.AgendaId));
        }

        public async Task AddModel(AddModelDTO dto)
        {
            var transaction =  await _repository.CreateTransaction();
            await _agendaModelRepository.Create(new AgendaModelEntity() { AgendaId = dto.AgendaId, ModelId = dto.ModelId});

            var model = await _modelWorkflowRespository.ModelWithRoles(dto.ModelId);
            var agenda = await _repository.DetailRoles(dto.AgendaId);
            var newRoles = new List<AgendaRoleEntity>();
            
            foreach (var role in model.WorkflowTasks.Select(x => x.ModelTask.Type))
            {
                if (!agenda.AgendaRoles.Any(x => x.Type == role))
                {
                    newRoles.Add(new AgendaRoleEntity() { AgendaId = dto.AgendaId, Type = role });
                }    
            }
            await _agendaRoleRepository.Create(newRoles);
            await _agendaRoleRepository.Save();
            
            await transaction.CommitAsync();
        }

        public async Task<List<AgendaModelDTO>> NewModels(int id)
        {
            return _mapper.Map<List<AgendaModelDTO>>(await _modelWorkflowRespository.NewModels(id));
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
            agenda.AdministratorId = data.AdminId;
            await _repository.Save();
        }

        public async Task<AgendaDetailDTO> RemoveRole(int id, int userId)
        {
            var role = await _agendaRoleRepository.Detail(id);
            _agendaRoleRepository.Delete(role);
            await _agendaRoleRepository.Save();
            
            return await Detail(role.AgendaId);
        }

        public async Task<AgendaDetailDTO> AddRole(NewRoleDTO role, int userId)
        {
            var roleEntity = _mapper.Map<AgendaRoleEntity>(role);
            await _agendaRoleRepository.Create(roleEntity);
            await _agendaRoleRepository.Save();
            
            return await Detail(role.AgendaId);
        }
    }
}
