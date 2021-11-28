using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.DAL.Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected readonly ItuDbContext _context = null;
        protected readonly DbSet<T> _dbSet = null;

        public BaseRepository(ItuDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }

        public async Task Create(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Create(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IDbContextTransaction> CreateTransaction()
        {
            return await _context.Database.BeginTransactionAsync();
        }
    }
}
