using itu.DAL.Entities;
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
    }
}
