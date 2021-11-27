using itu.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.DAL.Repositories
{
    public class AgendaRoleRepository : BaseRepository<AgendaRoleEntity>
    {
        public AgendaRoleRepository(ItuDbContext context) : base(context) { }

        public Task<List<AgendaRoleEntity>> AllOfAgenda(int agendaId)
        {
            return _dbSet.Where(x => x.AgendaId == agendaId)
                         .Include(x => x.User)
                         .ToListAsync();
        }

        public Task<AgendaRoleEntity> Detail(int roleId)
        {
            return _dbSet.FirstAsync(x => x.Id == roleId);
        }
    }
}
