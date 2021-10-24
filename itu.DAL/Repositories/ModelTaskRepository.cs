using itu.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.DAL.Repositories
{
    public class ModelTaskRepository : BaseRepository<ModelTaskEntity>
    {
        public ModelTaskRepository(ItuDbContext context) : base(context) { }
    }
}
