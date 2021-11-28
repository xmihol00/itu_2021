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


        public async Task<List<WorkflowEntity>> GetAllWorkflows()
        {
            return _context.Workflows.Include(y => y.Agenda).Include(z => z.Tasks).Where(x => x.Id != 0).ToList();
        }

        public Task<WorkflowEntity> GetDetail(int id)
        {
            return _context.Workflows
                .Include(a => a.Agenda)
                .Include(b => b.Files)
                .Include(c => c.ModelWorkflow)
                .Include(d => d.Tasks)
                .FirstAsync(x => x.Id == id);
        }

        public async Task<List<ModelWorkflowEntity>> GetAllModels()
        {
            return _context.ModelWorkflows.ToList();
        }

        public async Task<List<WorkflowEntity>> GetWorkflowsByAgenda(List<string> names)
        {
            List<WorkflowEntity> workflows = new List<WorkflowEntity>();
            foreach (var name in names)
            {
                workflows.Add(_context.Workflows.Include(a => a.Agenda)
                .Include(b => b.Files)
                .Include(c => c.ModelWorkflow)
                .Include(d => d.Tasks)
                .FirstOrDefault(x => x.Agenda.Name == name));
            }
            return workflows;
        }
        public async Task<List<WorkflowEntity>> GetWorkflowsByModel(List<string> names)
        {
            List<WorkflowEntity> workflows = new List<WorkflowEntity>();
            foreach (var name in names)
            {
                workflows.Add(_context.Workflows.Include(a => a.ModelWorkflow).Include(b => b.Files)
                .Include(c => c.ModelWorkflow)
                .Include(d => d.Tasks)
                .FirstOrDefault(x => x.ModelWorkflow.Name == name));
            }
            return workflows;
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
