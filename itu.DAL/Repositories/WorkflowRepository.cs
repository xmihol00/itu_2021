using itu.Common.Enums;
using itu.DAL.Entities;
using itu.DAL.Entities.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace itu.DAL.Repositories
{
    public class WorkflowRepository : BaseRepository<WorkflowEntity>
    {
        public WorkflowRepository(ItuDbContext context) : base(context) { }


        public Task<List<WorkflowEntity>> GetAllWorkflows()
        {
            return _context.Workflows.Include(a => a.Agenda)
                .Include(b => b.Files)
                .Include(c => c.ModelWorkflow)
                .ThenInclude(e => e.WorkflowTasks)
                .ThenInclude(g => g.ModelTask)
                .Include(d => d.Tasks).Where(x => x.Id != 0).ToListAsync();
        }

        public Task<WorkflowEntity> GetDetail(int id)
        {
            return _context.Workflows
                .Include(a => a.Agenda)
                .Include(b => b.Files)
                .Include(c => c.ModelWorkflow)
                .ThenInclude(e => e.WorkflowTasks)
                .ThenInclude(g => g.ModelTask)
                .Include(d => d.Tasks)
                .FirstAsync(x => x.Id == id);
        }

        public Task<WorkflowEntity> GetForEdit(int id)
        {
            return _context.Workflows.FirstAsync(x => x.Id == id);
        }

        public Task<List<ModelWorkflowEntity>> GetAllModels()
        {
            return _context.ModelWorkflows.ToListAsync();
        }

        public List<WorkflowEntity> GetWorkflowsByAgenda(List<int> Ids)
        {
            List<WorkflowEntity> workflows = new List<WorkflowEntity>();
            foreach (var id in Ids)
            {
                workflows.AddRange(_context.Workflows.Include(a => a.Agenda)
                .Include(b => b.Files)
                .Include(c => c.ModelWorkflow)
                .ThenInclude(e => e.WorkflowTasks)
                .ThenInclude(g => g.ModelTask)
                .Include(d => d.Tasks)
                .Where(x => x.Agenda.Id == id));
            }
            return workflows;
            //return _dbSet.Where(x => Ids.All(y => x.Agenda.Id == y)).ToList();
        }
        public List<WorkflowEntity> GetWorkflowsByModel(List<int> Ids)
        {
            List<WorkflowEntity> workflows = new List<WorkflowEntity>();
            foreach (var id in Ids)
            {
                workflows.AddRange(_context.Workflows.Include(a => a.ModelWorkflow).Include(b => b.Files)
                .Include(c => c.ModelWorkflow)
                .ThenInclude(e => e.WorkflowTasks)
                .ThenInclude(g => g.ModelTask)
                .Include(d => d.Tasks)
                .Include(e => e.Agenda)
                .Where(x => x.ModelWorkflow.Id == id));
            }
            return workflows;
            //return _dbSet.Where(x => Ids.All(y => x.ModelWorkflow.Id == y)).ToList();
        }

        public Task<ModelWorkflowEntity> GetWorkflowModel(int id)
        {
            return _context.ModelWorkflows.FirstOrDefaultAsync(x => x.Id == id);
        }
        //public async Task<List<WorkflowEntity>> GetWorkflowsByTask(List<string> types)
        //{
        //    List<WorkflowEntity> workflows = new List<WorkflowEntity>();
        //    foreach (var type in types)
        //    {
        //        workflows.Add(_context.Workflows.Include(a => a.Tasks).Where(x ));
        //    }
        //    return workflows;
        //}


    }
}
