using itu.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.DAL.Repositories
{
    public class AgendaRepository : BaseRepository<AgendaEntity>
    {
        public AgendaRepository(ItuDbContext context) : base(context) { }

        public Task<List<AgendaEntity>> All()
        {
            return _dbSet.Include(x => x.Workflows)
                            .ThenInclude(x => x.ModelWorkflow)
                         .Include(x => x.AgendaRoles)
                         .ToListAsync();
        }

        public Task<AgendaEntity> Detail(int id)
        {
            return _dbSet.Include(x => x.AgendaRoles)
                            .ThenInclude(x => x.User)
                         .Include(x => x.Administrator)
                         .Include(x => x.Workflows)
                            .ThenInclude(x => x.Tasks)
                         .Include(x => x.Workflows)
                            .ThenInclude(x => x.ModelWorkflow) 
                         .FirstAsync(x => x.Id == id);
        }
    }
}
