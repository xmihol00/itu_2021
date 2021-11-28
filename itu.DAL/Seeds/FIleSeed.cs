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
using itu.Common.Enums;
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
                Name = "test soubor.c",
                Number = "ID_852",
                MIME = "text/plain",
                WorkflowId = 1,
                Version = 1,
                FileDataId = 1,
                Type = FileTypeEnum.Assignment,
            },
            new FileEntity()
            {
                Id = 2,
                Name = "soubor1.txt",
                Number = "ID_7823",
                MIME = "text/plain",
                WorkflowId = 1,
                Version = 1,
                FileDataId = 2,
                Type = FileTypeEnum.Assignment,
            },
            new FileEntity()
            {
                Id = 3,
                Name = "soubor2.txt",
                Number = "ID_11",
                MIME = "text/plain",
                WorkflowId = 2,
                Version = 1,
                FileDataId = 3,
                Type = FileTypeEnum.Acceptation,
            },
        };

        public static void SeedFiles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileEntity>().HasData(_files);
        }
    }
}
