//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       Marek Fiala
// Kontakt:     xfiala60@stud.fit.vutbr.cz
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
                         .Include(x => x.AgendaModels)
                            .ThenInclude(x => x.Model)
                         .FirstAsync(x => x.Id == id);
        }

        public Task<AgendaEntity> DetailForEdit(int id)
        {
            return _dbSet.FirstAsync(x => x.Id == id);
        }

        public Task<AgendaEntity> DetailRoles(int agendaId)
        {
            return _dbSet.Include(x => x.AgendaRoles)
                         .FirstAsync(x => x.Id == agendaId);
        }

        public Task<int?> NextUserId(int agendaId, TaskTypeEnum type)
        {
            return _dbSet.Include(x => x.AgendaRoles)
                         .Where(x => x.Id == agendaId)
                         .SelectMany(x => x.AgendaRoles)
                         .Where(x => x.Type == type)
                         .Select(x => x.UserId)
                         .FirstAsync();
        }

        public Task<int> AdminId(int agendaId)
        {
            return _dbSet.Where(x => x.Id == agendaId)
                         .Select(x => x.AdministratorId)
                         .FirstAsync();
        }
    }
}
