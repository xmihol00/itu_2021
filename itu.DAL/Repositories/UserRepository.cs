using itu.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.DAL.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>
    {
        public UserRepository(ItuDbContext context) : base(context) { }

        public Task<UserEntity> Authenticate(string userName, string password)
        {
            return _dbSet.FirstAsync(x => x.UserName == userName && x.Password == password);
        }
    }
}
