using System.Collections.Generic;
using System;
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
            },
            new UserEntity()
            {
                Id = 3,
                FirstName = "User",
                LastName = "1",
                UserName = "u1",
                Password = "test"
            },
            new UserEntity()
            {
                Id = 4,
                FirstName = "User",
                LastName = "2",
                UserName = "u2",
                Password = "test"
            },
            new UserEntity()
            {
                Id = 5,
                FirstName = "User",
                LastName = "3",
                UserName = "u3",
                Password = "test"
            },
            new UserEntity()
            {
                Id = 6,
                FirstName = "User",
                LastName = "4",
                UserName = "u4",
                Password = "test"
            },
            new UserEntity()
            {
                Id = 7,
                FirstName = "User",
                LastName = "5",
                UserName = "u5",
                Password = "test"
            },
            new UserEntity()
            {
                Id = 8,
                FirstName = "User",
                LastName = "6",
                UserName = "u6",
                Password = "test"
            },
            new UserEntity()
            {
                Id = 9,
                FirstName = "User",
                LastName = "7",
                UserName = "u7",
                Password = "test"
            },
            new UserEntity()
            {
                Id = 10,
                FirstName = "User",
                LastName = "8",
                UserName = "u8",
                Password = "test"
            },
            new UserEntity()
            {
                Id = 11,
                FirstName = "User",
                LastName = "9",
                UserName = "u9",
                Password = "test"
            },
            new UserEntity()
            {
                Id = 12,
                FirstName = "User",
                LastName = "10",
                UserName = "u10",
                Password = "test"
            },
        };

        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(_users);
        }
    }
}
