using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace itu.DAL.Seeds
{
    public static class UserSeed
    {
        public static readonly List<UserEntity> _users = new List<UserEntity>()
        {
            new UserEntity()
            {
                Id = 1,
                FirstName = "Super",
                LastName = "User",
                UserName = "su",
                Password = "test"
            },

            new UserEntity()
            {
                Id = 2,
                FirstName = "System",
                LastName = "Admin",
                UserName = "admin",
                Password = "admin"
            }
        };

        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            foreach (UserEntity user in _users)
            {
                modelBuilder.Entity<UserEntity>().HasData(user);
            }
        }
    }
}
