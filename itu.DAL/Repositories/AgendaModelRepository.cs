//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       Marek Fiala
// Kontakt:     xfiala60@stud.fit.vutbr.cz
//=================================================================================================================

using itu.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.DAL.Repositories
{
    public class AgendaModelRepository : BaseRepository<AgendaModelEntity>
    {
        public AgendaModelRepository(ItuDbContext context) : base(context) { }

        public Task<AgendaModelEntity> Detail(int modelId, int agedaId)
        {
            return _dbSet.FirstAsync(x => x.ModelId == modelId && x.AgendaId == agedaId);
        }
    }
}
