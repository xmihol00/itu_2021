using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using itu.BL.DTOs.File;
using itu.BL.DTOs.Task;
using itu.Common.Enums;
using itu.DAL.Entities;
using itu.DAL.Entities.Tasks;
using itu.DAL.Entities.Tasks.Interfaces;
using itu.DAL.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

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

        public async Task<OverviewDTO> ActiveOfUser(int userId, int selected = 0)
        {
            OverviewDTO overview = new OverviewDTO();
            overview.Tasks = _mapper.Map<List<AllTaskDTO>>(await _repository.ActiveOfUser(userId));
            if (overview.Tasks.Count > 0)
            {
                if (selected <= 0)
                {
                    selected = overview.Tasks[0].Id;
                }

                overview.Detail = _mapper.Map<DetailTaskDTO>(await _repository.Detail(userId, selected));
            }
            overview.Selected = selected;

            return overview;
        }

        public async Task<OverviewDTO> DelayedOfUser(int userId, int selected = 0)
        {
            OverviewDTO overview = new OverviewDTO();
            overview.Tasks = _mapper.Map<List<AllTaskDTO>>(await _repository.DelayedOfUser(userId));
            if (overview.Tasks.Count > 0)
            {
                if (selected <= 0)
                {
                    selected = overview.Tasks[0].Id;
                }

                overview.Detail = _mapper.Map<DetailTaskDTO>(await _repository.Detail(userId, selected));
            }
            overview.Selected = selected;

            return overview;
        }

        public async Task<OverviewDTO> SolvedOfUser(int userId, int selected = 0)
        {
            OverviewDTO overview = new OverviewDTO();
            overview.Tasks = _mapper.Map<List<AllTaskDTO>>(await _repository.SolvedOfUser(userId));
            if (overview.Tasks.Count > 0)
            {
                if (selected <= 0)
                {
                    selected = overview.Tasks[0].Id;
                }

                overview.Detail = _mapper.Map<DetailTaskDTO>(await _repository.Detail(userId, selected));
            }
            overview.Selected = selected;

            return overview;
        }

        public async Task<DetailTaskDTO> Detail(int userId, int taskId)
        {
            return _mapper.Map<DetailTaskDTO>(await _repository.Detail(userId, taskId));
        }

        public async Task<DetailTaskDTO> AssignmentSave(int userId, AssignmentPostDTO model)
        {
            TaskEntity task = await _repository.Detail(userId, model.Id);
            IAssignmentEntity assignment = task as IAssignmentEntity;

            assignment.Benefit = model.Benefit;
            assignment.Currency = model.Currency;
            assignment.Note = model.Note;
            assignment.PriceGues = model.PriceGues;

            await _repository.Save();

            return _mapper.Map<DetailTaskDTO>(task);
        }

        public async Task<SolvedDTO> AssignmentSolve(int userId, AssignmentPostDTO dto)
        {
            TaskEntity task = await _repository.Detail(userId, dto.Id);

            IAssignmentEntity assignment = task as IAssignmentEntity;
            assignment.Benefit = dto.Benefit;
            assignment.Currency = dto.Currency;
            assignment.Note = dto.Note;
            assignment.PriceGues = dto.PriceGues;
            assignment.Active = false;
            assignment.End = DateTime.Now;

            (int nextUserId, TaskEntity created) = await CreateNextTask(task);            
            return new SolvedDTO() 
            { 
                NextUserId = nextUserId,
                Overview = await ActiveOfUser(userId),
                CreatedTask = created != null ? _mapper.Map<AllTaskDTO>(created) : null
            };
        }

        public async Task<DetailTaskDTO> AcceptationSave(int userId, AcceptationPostDTO dto)
        {
            TaskEntity task = await _repository.Detail(userId, dto.Id);
            IAcceptationEntity acceptation = task as IAcceptationEntity;

            acceptation.Accepted = dto.Accepted;
            acceptation.DelayReason = dto.DelayReason;
            acceptation.Reason = dto.Reason;
            acceptation.Note = dto.Note;

            await _repository.Save();

            return _mapper.Map<DetailTaskDTO>(task);
        }

        public async Task<SolvedDTO> AcceptationSolve(int userId, AcceptationPostDTO dto)
        {
            TaskEntity task = await _repository.Detail(userId, dto.Id);
            IAcceptationEntity acceptation = task as IAcceptationEntity;

            acceptation.Accepted = dto.Accepted;
            acceptation.DelayReason = dto.DelayReason;
            acceptation.Reason = dto.Reason;
            acceptation.Note = dto.Note;
            acceptation.Active = false;
            acceptation.End = DateTime.Now;

            if (acceptation.Accepted)
            {
                (int nextUserId, TaskEntity created) = await CreateNextTask(task);            
                return new SolvedDTO() 
                { 
                    NextUserId = nextUserId,
                    Overview = await ActiveOfUser(userId),
                    CreatedTask = created != null ? _mapper.Map<AllTaskDTO>(created) : null
                };
            }
            else
            {
                task.Workflow.State = WorkflowStateEnum.Canceled;
                await _repository.Save();

                return new SolvedDTO()
                {
                    NextUserId = 0,
                    Overview = await ActiveOfUser(userId),
                    CreatedTask = null
                };
            }

        }

        public async Task<DetailTaskDTO> AssessmentSave(int userId, AssessmentPostDTO dto)
        {
            TaskEntity task = await _repository.Detail(userId, dto.Id);
            IAssessmentEntity assessment = task as IAssessmentEntity;

            assessment.Conclusion = dto.Conclusion;
            assessment.Note = dto.Note;
            assessment.DelayReason = assessment.DelayReason;

            await _repository.Save();

            return _mapper.Map<DetailTaskDTO>(task);
        }

        public async Task<SolvedDTO> AssessmentSolve(int userId, AssessmentPostDTO dto)
        {
            TaskEntity task = await _repository.Detail(userId, dto.Id);
            IAssessmentEntity assessment = task as IAssessmentEntity;

            assessment.Conclusion = dto.Conclusion;
            assessment.Note = dto.Note;
            assessment.DelayReason = assessment.DelayReason;
            assessment.Active = false;
            assessment.End = DateTime.Now;

            (int nextUserId, TaskEntity created) = await CreateNextTask(task);            
            return new SolvedDTO() 
            { 
                NextUserId = nextUserId,
                Overview = await ActiveOfUser(userId),
                CreatedTask = created != null ? _mapper.Map<AllTaskDTO>(created) : null
            };
        }

        public async Task<DetailTaskDTO> EstimateSave(int userId, EstimatePostDTO dto)
        {
            TaskEntity task = await _repository.Detail(userId, dto.Id);
            IEstimateEntity estimate = task as IEstimateEntity;

            estimate.EstimatePrice = dto.EstimatePrice;
            estimate.MaxPrice = dto.MaxPrice;
            estimate.Note = dto.Note;
            estimate.DelayReason = estimate.DelayReason;

            await _repository.Save();

            return _mapper.Map<DetailTaskDTO>(task);
        }

        public async Task<SolvedDTO> EstimateSolve(int userId, EstimatePostDTO dto)
        {
            TaskEntity task = await _repository.Detail(userId, dto.Id);
            IEstimateEntity estimate = task as IEstimateEntity;

            estimate.EstimatePrice = dto.EstimatePrice;
            estimate.MaxPrice = dto.MaxPrice;
            estimate.Note = dto.Note;
            estimate.DelayReason = estimate.DelayReason;
            estimate.Active = false;
            estimate.End = DateTime.Now;

            (int nextUserId, TaskEntity created) = await CreateNextTask(task);            
            return new SolvedDTO() 
            { 
                NextUserId = nextUserId,
                Overview = await ActiveOfUser(userId),
                CreatedTask = created != null ? created != null ? _mapper.Map<AllTaskDTO>(created) : null : null
            };
        }

        public async Task<DetailTaskDTO> PublicationSave(int userId, PublishPostDTO dto)
        {
            TaskEntity task = await _repository.Detail(userId, dto.Id);
            IPublishEntity publish = task as IPublishEntity;

            publish.PublishStart = dto.PublishStart;
            publish.PublishEnd = dto.PublishEnd;
            publish.Note = dto.Note;
            publish.DelayReason = publish.DelayReason;

            await _repository.Save();

            return _mapper.Map<DetailTaskDTO>(task);
        }

        public async Task<SolvedDTO> PublicationSolve(int userId, PublishPostDTO dto)
        {
            TaskEntity task = await _repository.Detail(userId, dto.Id);
            IPublishEntity publish = task as IPublishEntity;

            publish.PublishStart = dto.PublishStart;
            publish.PublishEnd = dto.PublishEnd;
            publish.Note = dto.Note;
            publish.DelayReason = publish.DelayReason;
            publish.Active = false;
            publish.End = DateTime.Now;

            (int nextUserId, TaskEntity created) = await CreateNextTask(task);            
            return new SolvedDTO() 
            { 
                NextUserId = nextUserId,
                Overview = await ActiveOfUser(userId),
                CreatedTask = created != null ? _mapper.Map<AllTaskDTO>(created) : null
            };
        }

        public async Task<DetailTaskDTO> ContractSave(int userId, ContractPostDTO dto)
        {
            TaskEntity task = await _repository.Detail(userId, dto.Id);
            IContractEntity contract = task as IContractEntity;

            contract.ContractType = dto.ContractType;
            contract.FinalPrice = dto.FinalPrice;
            contract.PriceChangeReason = dto.PriceChangeReason;
            contract.Note = dto.Note;
            contract.DelayReason = contract.DelayReason;
            contract.Currency = dto.Currency;

            await _repository.Save();

            return _mapper.Map<DetailTaskDTO>(task);
        }

        public async Task<SolvedDTO> ContractSolve(int userId, ContractPostDTO dto)
        {
            TaskEntity task = await _repository.Detail(userId, dto.Id);
            IContractEntity contract = task as IContractEntity;

            contract.ContractType = dto.ContractType;
            contract.FinalPrice = dto.FinalPrice;
            contract.PriceChangeReason = dto.PriceChangeReason;
            contract.Note = dto.Note;
            contract.DelayReason = contract.DelayReason;
            contract.Active = false;
            contract.Currency = dto.Currency;
            contract.End = DateTime.Now;

            (int nextUserId, TaskEntity created) = await CreateNextTask(task);            
            return new SolvedDTO() 
            { 
                NextUserId = nextUserId,
                Overview = await ActiveOfUser(userId),
                CreatedTask = created != null ? _mapper.Map<AllTaskDTO>(created) : null
            };
        }

        public async Task<DetailTaskDTO> ArchivationSave(int userId, ArchivationPostDTO dto)
        {
            TaskEntity task = await _repository.Detail(userId, dto.Id);
            IArchivationEntity archivation = task as IArchivationEntity;

            archivation.Cancallation = dto.Cancallation;
            archivation.Number = dto.Number;
            archivation.Location = dto.Location;
            archivation.Note = dto.Note;
            archivation.DelayReason = archivation.DelayReason;

            await _repository.Save();

            return _mapper.Map<DetailTaskDTO>(task);
        }

        public async Task<SolvedDTO> ArchivationSolve(int userId, ArchivationPostDTO dto)
        {
            TaskEntity task = await _repository.Detail(userId, dto.Id);
            IArchivationEntity archivation = task as IArchivationEntity;

            archivation.Cancallation = dto.Cancallation;
            archivation.Number = dto.Number;
            archivation.Location = dto.Location;
            archivation.Note = dto.Note;
            archivation.DelayReason = archivation.DelayReason;
            archivation.Active = false;
            archivation.End = DateTime.Now;

            (int nextUserId, TaskEntity created) = await CreateNextTask(task);
            return new SolvedDTO() 
            { 
                NextUserId = nextUserId,
                Overview = await ActiveOfUser(userId),
                CreatedTask = created != null ? _mapper.Map<AllTaskDTO>(created) : null
            };
        }

        private async Task<(int, TaskEntity)> CreateNextTask(TaskEntity current)
        {
            ModelTaskEntity model = await _repository.NextModel(current.Id, current.Order + 1);
            int nextUserId = 0;
            TaskEntity created = null;
            
            if (model == null)
            {
                current.Workflow.State = WorkflowStateEnum.Finished;
            }
            else
            {
                nextUserId = (await _repository.NextUserId(current.Id, model.Type)).Value;
                switch (model.Type)
                {
                    case TaskTypeEnum.Acceptation:
                        AcceptationEntity acceptation = _mapper.Map<AcceptationEntity>(current);
                        if (current is IAssignmentEntity)
                        {
                            IAssignmentEntity iAssignment = current as IAssignmentEntity;
                            acceptation.Benefit = iAssignment.Benefit;
                            acceptation.Currency = iAssignment.Currency;
                            acceptation.PriceGues = iAssignment.PriceGues;
                        }
                        acceptation.End = DateTime.Now.AddDays(model.Difficulty);
                        acceptation.UserId = nextUserId;

                        await _repository.Create(acceptation);
                        created = acceptation;
                        break;

                    case TaskTypeEnum.Archivation:
                        ArchivationEntity archivation = _mapper.Map<ArchivationEntity>(current);
                        archivation.End = DateTime.Now.AddDays(model.Difficulty);
                        archivation.UserId = nextUserId;

                        await _repository.Create(archivation);
                        created = archivation;
                        break;

                    case TaskTypeEnum.Assessment:
                        AssessmentEntity assessment = _mapper.Map<AssessmentEntity>(current);
                        assessment.End = DateTime.Now.AddDays(model.Difficulty);
                        assessment.UserId = nextUserId;

                        await _repository.Create(assessment);
                        created = assessment;
                        break;

                    case TaskTypeEnum.Contract:
                        ContractEntity contract = _mapper.Map<ContractEntity>(current);
                        contract.End = DateTime.Now.AddDays(model.Difficulty);
                        contract.UserId = nextUserId;

                        await _repository.Create(contract);
                        created = contract;
                        break;
                    
                    case TaskTypeEnum.Publish:
                        PublishEntity publication = _mapper.Map<PublishEntity>(current);
                        publication.End = DateTime.Now.AddDays(model.Difficulty);
                        publication.UserId = nextUserId;

                        await _repository.Create(publication);
                        created = publication;
                        break;

                    case TaskTypeEnum.Estimate:
                        EstimateEntity estimate = _mapper.Map<EstimateEntity>(current);
                        estimate.End = DateTime.Now.AddDays(model.Difficulty);
                        estimate.UserId = nextUserId;

                        if (current is IAssignmentEntity)
                        {
                            estimate.Currency = (current as IAssignmentEntity).Currency;
                        }
                        else if (current is IAcceptationEntity)
                        {
                            estimate.Currency = (current as IAcceptationEntity).Currency;
                        }

                        await _repository.Create(estimate);
                        created = estimate;
                        break;

                    case TaskTypeEnum.Assignment:
                        AssignmentEntity assignment = _mapper.Map<AssignmentEntity>(current);
                        assignment.End = DateTime.Now.AddDays(model.Difficulty);
                        assignment.UserId = nextUserId;

                        await _repository.Create(assignment);
                        created = assignment;
                        break;
                }
            }

            await _repository.Save();
            return (nextUserId, created);
        }
    }
}
