﻿using System;
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

        public async Task<OverviewDTO> AllOfUser(int userId)
        {
            OverviewDTO overview = new OverviewDTO();
            overview.Tasks = _mapper.Map<List<AllTaskDTO>>(await _repository.AllOfUser(userId));
            if (overview.Tasks.Count > 0)
            {
                overview.Detail = _mapper.Map<DetailTaskDTO>(await _repository.Detail(userId, overview.Tasks[0].Id));
            }

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

        public async Task AssignmentSolve(int userId, AssignmentPostDTO dto)
        {
            TaskEntity task = await _repository.Detail(userId, dto.Id);

            IAssignmentEntity assignment = task as IAssignmentEntity;
            assignment.Benefit = dto.Benefit;
            assignment.Currency = dto.Currency;
            assignment.Note = dto.Note;
            assignment.PriceGues = dto.PriceGues;
            assignment.Active = false;

            await CreateNextTask(task);            
            await _repository.Save();
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

        public async Task AcceptationSolve(int userId, AcceptationPostDTO dto)
        {
            TaskEntity task = await _repository.Detail(userId, dto.Id);
            IAcceptationEntity acceptation = task as IAcceptationEntity;

            acceptation.Accepted = dto.Accepted;
            acceptation.DelayReason = dto.DelayReason;
            acceptation.Reason = dto.Reason;
            acceptation.Note = dto.Note;
            acceptation.Active = false;

            await CreateNextTask(task);            
            await _repository.Save();
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

        public async Task AssessmentSolve(int userId, AssessmentPostDTO dto)
        {
            TaskEntity task = await _repository.Detail(userId, dto.Id);
            IAssessmentEntity assessment = task as IAssessmentEntity;

            assessment.Conclusion = dto.Conclusion;
            assessment.Note = dto.Note;
            assessment.DelayReason = assessment.DelayReason;
            assessment.Active = false;

            await CreateNextTask(task);            
            await _repository.Save();
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

        public async Task EstimateSolve(int userId, EstimatePostDTO dto)
        {
            TaskEntity task = await _repository.Detail(userId, dto.Id);
            IEstimateEntity estimate = task as IEstimateEntity;

            estimate.EstimatePrice = dto.EstimatePrice;
            estimate.MaxPrice = dto.MaxPrice;
            estimate.Note = dto.Note;
            estimate.DelayReason = estimate.DelayReason;
            estimate.Active = false;

            await CreateNextTask(task);            
            await _repository.Save();
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

        public async Task PublicationSolve(int userId, PublishPostDTO dto)
        {
            TaskEntity task = await _repository.Detail(userId, dto.Id);
            IPublishEntity publish = task as IPublishEntity;

            publish.PublishStart = dto.PublishStart;
            publish.PublishEnd = dto.PublishEnd;
            publish.Note = dto.Note;
            publish.DelayReason = publish.DelayReason;
            publish.Active = false;

            await CreateNextTask(task);            
            await _repository.Save();
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

            await _repository.Save();

            return _mapper.Map<DetailTaskDTO>(task);
        }

        public async Task ContractSolve(int userId, ContractPostDTO dto)
        {
            TaskEntity task = await _repository.Detail(userId, dto.Id);
            IContractEntity contract = task as IContractEntity;

            contract.ContractType = dto.ContractType;
            contract.FinalPrice = dto.FinalPrice;
            contract.PriceChangeReason = dto.PriceChangeReason;
            contract.Note = dto.Note;
            contract.DelayReason = contract.DelayReason;
            contract.Active = false;

            await CreateNextTask(task);            
            await _repository.Save();
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

        public async Task ArchivationSolve(int userId, ArchivationPostDTO dto)
        {
            TaskEntity task = await _repository.Detail(userId, dto.Id);
            IArchivationEntity archivation = task as IArchivationEntity;

            archivation.Cancallation = dto.Cancallation;
            archivation.Number = dto.Number;
            archivation.Location = dto.Location;
            archivation.Note = dto.Note;
            archivation.DelayReason = archivation.DelayReason;
            archivation.Active = false;

            await CreateNextTask(task);            
            await _repository.Save();
        }

        private async Task CreateNextTask(TaskEntity current)
        {
            ModelTaskEntity model = await _repository.NextModel(current.Id, current.Order + 1);
            int nextUserId = (await _repository.NextUserId(current.Id, model.Type)).Value;
            
            if (model == null)
            {
                _repository.CompleteWorkflow(current.WorkflowId);
            }
            else
            {
                switch (model.Type)
                {
                    case TaskTypeEnum.Acceptation:
                        AcceptationEntity acceptation = _mapper.Map<AcceptationEntity>(current);
                        if (current is IAssignmentEntity)
                        {
                            IAssignmentEntity iAssignment = current as IAssignmentEntity;
                            acceptation.Order = iAssignment.Order++;
                            acceptation.Benefit = iAssignment.Benefit;
                            acceptation.Currency = iAssignment.Currency;
                            acceptation.PriceGues = iAssignment.PriceGues;
                        }
                        acceptation.End = DateTime.Now.AddDays(model.Difficulty);
                        acceptation.UserId = nextUserId;

                        await _repository.Create(acceptation);
                        break;

                    case TaskTypeEnum.Archivation:
                        ArchivationEntity archivation = _mapper.Map<ArchivationEntity>(current);
                        archivation.End = DateTime.Now.AddDays(model.Difficulty);
                        archivation.UserId = nextUserId;

                        await _repository.Create(archivation);
                        break;

                    case TaskTypeEnum.Assessment:
                        AssessmentEntity assessment = _mapper.Map<AssessmentEntity>(current);
                        assessment.End = DateTime.Now.AddDays(model.Difficulty);
                        assessment.UserId = nextUserId;

                        await _repository.Create(assessment);
                        break;

                    case TaskTypeEnum.Contract:
                        ContractEntity contract = _mapper.Map<ContractEntity>(current);
                        contract.End = DateTime.Now.AddDays(model.Difficulty);
                        contract.UserId = nextUserId;

                        await _repository.Create(contract);
                        break;
                    
                    case TaskTypeEnum.Publish:
                        PublishEntity publication = _mapper.Map<PublishEntity>(current);
                        publication.End = DateTime.Now.AddDays(model.Difficulty);
                        publication.UserId = nextUserId;

                        await _repository.Create(publication);
                        break;

                    case TaskTypeEnum.Estimate:
                        EstimateEntity estimate = _mapper.Map<EstimateEntity>(current);
                        estimate.End = DateTime.Now.AddDays(model.Difficulty);
                        estimate.UserId = nextUserId;

                        await _repository.Create(estimate);
                        break;

                    case TaskTypeEnum.Assignment:
                        AssignmentEntity assignment = _mapper.Map<AssignmentEntity>(current);
                        assignment.End = DateTime.Now.AddDays(model.Difficulty);
                        assignment.UserId = nextUserId;

                        await _repository.Create(assignment);
                        break;
                }
            }
        }
    }
}
