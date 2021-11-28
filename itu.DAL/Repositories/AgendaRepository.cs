using itu.DAL.Entities;
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

        public async Task<AgendaEntity> GetAgenda(int id)
        {
            return _context.Workflows.Select(y => y.Agenda).FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<AgendaEntity>> GetAll()
        {
            return _context.Agendas.ToList();
        }
    }
}
