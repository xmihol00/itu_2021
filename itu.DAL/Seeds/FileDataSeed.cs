using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using itu.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace itu.DAL.Seeds
{
    public static class FileDataSeed
    {
        private static readonly List<FileDataEntity> _fileData = new List<FileDataEntity>()
        {
            new FileDataEntity()
            {
                Id = 1,
                Data = new byte[] {5, 7, 8, 9, 10}   
            },
            new FileDataEntity()
            {
                Id = 2,
                Data = new byte[] {5, 7, 8, 9, 10}   
            },
            new FileDataEntity()
            {
                Id = 3,
                Data = new byte[] {5, 7, 8, 9, 10}   
            },
            
        };

        public static void SeedFileData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileDataEntity>().HasData(_fileData);
        }
    }
}