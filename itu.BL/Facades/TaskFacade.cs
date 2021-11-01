using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using itu.BL.DTOs.File;
using itu.BL.DTOs.Task;
using itu.DAL.Entities;
using itu.DAL.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace itu.BL.Facades
{
    public class TaskFacade
    {
        private readonly TaskRepository _repository;
        private readonly FileRepository _fileRepository;
        private readonly FileDataRepository _fileDataRepository;
        private readonly IMapper _mapper;

        public TaskFacade(TaskRepository repository, FileRepository fileRepository, FileDataRepository fileDataRepository, IMapper mapper)
        {
            _repository = repository;
            _fileRepository = fileRepository;
            _fileDataRepository = fileDataRepository;
            _mapper = mapper;
        }

        public async Task<IDbContextTransaction> Transaction()
        {
            return await _repository.CreateTransaction();
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

        public async Task Upload(FileUploadDTO upload)
        {
            FileEntity newFile = new FileEntity()
            {
                TaskId = upload.TaskId,
                Name = upload.Name,
                Number = upload.Number,
                FileData = new FileDataEntity()
            };

            MemoryStream memStream = new MemoryStream();
            await upload.File.OpenReadStream().CopyToAsync(memStream);
            newFile.FileData.Data = memStream.ToArray();

            await _fileRepository.Create(newFile);
            await _fileRepository.Save();
        }

        public async Task<DetailTaskDTO> Detail(int userId, int taskId)
        {
            return _mapper.Map<DetailTaskDTO>(await _repository.Detail(userId, taskId));
        }
    }
}
