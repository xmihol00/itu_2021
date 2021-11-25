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
    }
}
