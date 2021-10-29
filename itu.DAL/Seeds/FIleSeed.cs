using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using itu.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace itu.DAL.Seeds
{
    public static class FileSeed
    {
        private static readonly List<FileEntity> _files = new List<FileEntity>()
        {
            new FileEntity()
            {
                Id = 1,
                Name = "test soubor",
                TaskId = 1,
                FileDataId = 1,
            },
            new FileEntity()
            {
                Id = 2,
                Name = "soubor1",
                TaskId = 1,
                FileDataId = 2,
            },
            new FileEntity()
            {
                Id = 3,
                Name = "soubor ABC",
                TaskId = 1,
                FileDataId = 3,
            },
        };

        public static void SeedFiles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileEntity>().HasData(_files);
        }
    }
}
