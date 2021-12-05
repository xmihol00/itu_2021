//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       David Mihola
// Kontakt:     xmihol00@stud.fit.vutbr.cz
//=================================================================================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using itu.BL.DTOs.Account;
using itu.BL.DTOs.File;
using itu.DAL.Entities;
using itu.DAL.Repositories;
using Microsoft.AspNetCore.Http;

namespace itu.BL.Facades
{
    public class FileFacade
    {
        private readonly FileRepository _repository;
        private readonly TaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public FileFacade(FileRepository repository, TaskRepository taskRepository, IMapper mapper)
        {
            _repository = repository;
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<List<AllFileDTO>> Upload(int taskId, IFormFile file)
        {
            TaskEntity task = await _taskRepository.GetTask(taskId);
            FileEntity newFile = new FileEntity()
            {
                WorkflowId = task.WorkflowId,
                Name = file.FileName,
                Number = file.Name,
                MIME = file.ContentType,
                Type = task.ToType(),
                Version = (await _repository.HighestVersion(taskId, file.Name)) + 1,
                FileData = new FileDataEntity()
            };

            MemoryStream memStream = new MemoryStream();
            await file.OpenReadStream().CopyToAsync(memStream);
            newFile.FileData.Data = memStream.ToArray();

            await _repository.Create(newFile);
            await _repository.Save();

            return _mapper.Map<List<AllFileDTO>>(await _repository.AllFiles(task.WorkflowId));
        }

        public async Task<List<AllFileDTO>> Delete(int id)
        {
            FileEntity file = await _repository.GetFile(id);
            _repository.Delete(file);
            await _repository.Save();

            return _mapper.Map<List<AllFileDTO>>(await _repository.AllFiles(file.WorkflowId));
        }

        public async Task<DownloadFileDTO> Download(int id)
        {
            return _mapper.Map<DownloadFileDTO>(await _repository.Download(id));
        }

        public async Task<List<AllFileDTO>> ChnageVersion(VersionChangeDTO data)
        {
            FileEntity file = await _repository.GetFile(data.FileId);
            file.Version = data.Version;
            _repository.Update(file);
            await _repository.Save();

            return _mapper.Map<List<AllFileDTO>>(await _repository.AllFiles(file.WorkflowId));
        }
    }
}
