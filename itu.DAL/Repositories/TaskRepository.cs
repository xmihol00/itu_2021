using itu.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.DAL.Repositories
{
    public class TaskRepository : BaseRepository<TaskEntity>
    {
        public TaskRepository(ItuDbContext context) : base(context) { }

        public Task<List<TaskEntity>> AllOfUser(int userId)
        {
            return _dbSet.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
