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
            return _dbSet.Include(x => x.Workflow)
                         .Where(x => x.UserId == userId).ToListAsync();
        }

        public Task<TaskEntity> Detail(int userId, int taskId)
        {
            return _dbSet.Include(x => x.Workflow)
                            .ThenInclude(x => x.Agenda)
                         .Include(x => x.Workflow)
                            .ThenInclude(x => x.Files)
                         .FirstAsync(x => x.Id == taskId && x.UserId == userId);
        }

        public Task<TaskEntity> GetTask(int id)
        {
            return _dbSet.FirstAsync(x => x.Id == id);
        }
    }
}
