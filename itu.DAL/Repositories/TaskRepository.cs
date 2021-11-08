﻿using itu.Common.Enums;
using itu.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.DAL.Repositories
{
    public class TaskRepository : BaseRepository<TaskEntity>
    {
        public TaskRepository(ItuDbContext context) : base(context) { }

        public Task<List<TaskEntity>> ActiveOfUser(int userId)
        {
            return _dbSet.Include(x => x.Workflow)
                         .OrderBy(x => x.End.Date)
                            .ThenBy(x => x.Priority)
                         .Where(x => x.UserId == userId && x.Active == true)
                         .ToListAsync();
        }

        public Task<List<TaskEntity>> SolvedOfUser(int userId)
        {
            return _dbSet.Include(x => x.Workflow)
                         .OrderBy(x => x.End.Date)
                            .ThenBy(x => x.Priority)
                         .Where(x => x.UserId == userId && x.Active == false)
                         .ToListAsync();
        }

        public Task<TaskEntity> Detail(int userId, int taskId)
        {
            return _dbSet.Include(x => x.Workflow)
                            .ThenInclude(x => x.Agenda)
                         .Include(x => x.Workflow)
                            .ThenInclude(x => x.Files)
                         .FirstAsync(x => x.Id == taskId && x.UserId == userId);
        }

        public Task<TaskEntity> GetTask(int id)
        {
            return _dbSet.FirstAsync(x => x.Id == id);
        }

        public Task<ModelTaskEntity> NextModel(int id, int order)
        {
            return _dbSet.Include(x => x.Workflow)
                            .ThenInclude(x => x.ModelWorkflow)
                            .ThenInclude(x => x.WorkflowTasks)
                            .ThenInclude(x => x.ModelTask)
                         .Where(x => x.Id == id)
                         .SelectMany(x => x.Workflow.ModelWorkflow.WorkflowTasks)
                         .Where(x => x.Order == order)
                         .Select(x => x.ModelTask)
                         .FirstOrDefaultAsync();
        }

        public Task<int?> NextUserId(int id, TaskTypeEnum type)
        {
            return _dbSet.Include(x => x.Workflow)
                            .ThenInclude(x => x.Agenda)
                            .ThenInclude(x => x.AgendaRoles)
                         .Where(x => x.Id == id)
                         .SelectMany(x => x.Workflow.Agenda.AgendaRoles)
                         .Where(x => x.Type == type)
                         .Select(x => x.UserId)
                         .FirstOrDefaultAsync();
        }

        public void CompleteWorkflow(int workflowId)
        {
            _context.Workflows.Attach(new WorkflowEntity(){ Id = workflowId, State = WorkflowStateEnum.Finished })
                              .Property(x => x.State).IsModified = true;
        }

        public int TaskOfUserCount(int userId)
        {
            return _dbSet.Where(x => x.UserId == userId && x.Active)
                         .Count();
        }
    }
}
