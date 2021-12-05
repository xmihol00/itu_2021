//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       David Mihola
// Kontakt:     xmihol00@stud.fit.vutbr.cz
//=================================================================================================================

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
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 2,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 3,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 4,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 5,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 6,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 7,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 8,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 9,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 10,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 11,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 12,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 13,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 14,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 15,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 16,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 17,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 18,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 19,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 20,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 21,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 22,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 23,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 24,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 25,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 26,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 27,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 28,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 29,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 30,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
            new FileDataEntity()
            {
                Id = 31,
                Data = new byte[] {100, 117, 109, 109, 121, 10}   
            },
        };

        public static void SeedFileData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileDataEntity>().HasData(_fileData);
        }
    }
}
