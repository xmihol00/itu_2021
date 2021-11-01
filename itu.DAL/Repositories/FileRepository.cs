using itu.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.DAL.Repositories
{
    public class FileRepository : BaseRepository<FileEntity>
    {
        public FileRepository(ItuDbContext context) : base(context) { }

        public Task<int> HighestVersion(int taskId, string number)
        {
            return _dbSet.Where(x => x.TaskId == taskId && x.Number == number)
                         .OrderByDescending(x => x.Version)
                         .Select(x => x.Version)
                         .FirstOrDefaultAsync();
        }

        public Task<List<FileEntity>> AllFiles(int taskId)
        {
            return _dbSet.Where(x => x.TaskId == taskId).ToListAsync();
        }

        public Task<FileEntity> Download(int id)
        {
            return _dbSet.Include(x => x.FileData)
                         .FirstAsync(x => x.Id == id);
        }

        public Task<FileEntity> GetFile(int id)
        {
            return _dbSet.FirstAsync(x => x.Id == id);
        }

        public void ChangeVersion(int fileId, int version)
        {
            _dbSet.Attach(new FileEntity(){ Id = fileId, Version = version }).Property(x => x.Version).IsModified = true;
        }
    }
}
