﻿//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       David Mihola
// Kontakt:     xmihol00@stud.fit.vutbr.cz
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
    public class UserRepository : BaseRepository<UserEntity>
    {
        public UserRepository(ItuDbContext context) : base(context) { }

        public Task<UserEntity> Authenticate(string userName, string password)
        {
            return _dbSet.FirstAsync(x => x.UserName == userName && x.Password == password);
        }

        public Task<List<UserEntity>> All()
        {
            return _dbSet.ToListAsync();
        }
    }
}
