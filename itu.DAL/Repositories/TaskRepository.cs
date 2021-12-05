//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       David Mihola
// Kontakt:     xmihol00@stud.fit.vutbr.cz
//=================================================================================================================

using itu.Common.Enums;
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
                         .Where(x => x.UserId == userId && x.Active == true && x.Workflow.State == WorkflowStateEnum.Active)
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

        public Task<List<TaskEntity>> DelayedOfUser(int userId)
        {
            return _dbSet.Include(x => x.Workflow)
                         .OrderBy(x => x.End.Date)
                            .ThenBy(x => x.Priority)
                         .Where(x => x.UserId == userId && x.Active == true && 
                                x.End.Date < DateTime.Now.Date && x.Workflow.State == WorkflowStateEnum.Active)
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

        public Task<TaskEntity> Detail(int taskId)
        {
            return _dbSet.Include(x => x.Workflow)
                            .ThenInclude(x => x.Agenda)
                         .Include(x => x.User)
                         .Include(x => x.Workflow)
                            .ThenInclude(x => x.Files)
                         .FirstOrDefaultAsync(x => x.Id == taskId);
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

        public int TaskOfUserCount(int userId)
        {
            return _dbSet.Include(x => x.Workflow)
                         .Where(x => x.UserId == userId && x.Active && x.Workflow.State == WorkflowStateEnum.Active)
                         .Count();
        }

        public Task<List<TaskEntity>> GetActive()
        {
            return _dbSet.Where(x => x.Active == true).ToListAsync();
        }
    }
}
