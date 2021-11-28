using itu.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.DAL.Repositories
{
    public class ModelWorkflowRepository : BaseRepository<ModelWorkflowEntity>
    {
        public ModelWorkflowRepository(ItuDbContext context) : base(context) { }

        public Task<List<ModelWorkflowEntity>> NewModels(int agendaId)
        {
            return _dbSet.Include(x => x.AgendaModels)
                         .Where(x => x.AgendaModels.All(x => x.AgendaId != agendaId))
                         .ToListAsync();
        }

        public Task<ModelWorkflowEntity> ModelWithRoles(int modelId)
        {
            return _dbSet.Include(x => x.WorkflowTasks)
                            .ThenInclude(x => x.ModelTask)
                         .FirstAsync(x => x.Id == modelId);
        }

        public Task<ModelWorkflowEntity> Detail(int modelId)
        {
            return _dbSet.Include(x => x.WorkflowTasks)
                            .ThenInclude(x => x.ModelTask)
                         .FirstAsync(x => x.Id == modelId);
        }
    }
}
