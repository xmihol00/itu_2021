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
                Version = 2,
                FileDataId = 2,
                Type = FileTypeEnum.Assignment,
            },
            new FileEntity()
            {
                Id = 3,
                Name = "soubor2.txt",
                Number = "ID_11",
                MIME = "text/plain",
                WorkflowId = 1,
                Version = 1,
                FileDataId = 3,
                Type = FileTypeEnum.Acceptation,
            },
            new FileEntity()
            {
                Id = 4,
                Name = "soubor2.txt",
                Number = "ID_11",
                MIME = "text/plain",
                WorkflowId = 1,
                Version = 3,
                FileDataId = 4,
                Type = FileTypeEnum.Acceptation,
            },
            new FileEntity()
            {
                Id = 5,
                Name = "soubor2.txt",
                Number = "ID_11",
                MIME = "text/plain",
                WorkflowId = 1,
                Version = 3,
                FileDataId = 5,
                Type = FileTypeEnum.Acceptation,
            },


            new FileEntity()
            {
                Id = 6,
                Name = "vyhodnoceni.txt",
                Number = "ID_889",
                MIME = "text/plain",
                WorkflowId = 2,
                Version = 1,
                FileDataId = 6,
                Type = FileTypeEnum.Assignment,
            },
            new FileEntity()
            {
                Id = 7,
                Name = "vypracovani prijeti.txt",
                Number = "ID_890",
                MIME = "text/plain",
                WorkflowId = 2,
                Version = 1,
                FileDataId = 7,
                Type = FileTypeEnum.Acceptation,
            },
            new FileEntity()
            {
                Id = 8,
                Name = "odhad ceny.txt",
                Number = "ID_866",
                MIME = "text/plain",
                WorkflowId = 2,
                Version = 1,
                FileDataId = 8,
                Type = FileTypeEnum.Estimate,
            },
            new FileEntity()
            {
                Id = 9,
                Name = "odhad ceny.txt",
                Number = "ID_866",
                MIME = "text/plain",
                WorkflowId = 2,
                Version = 2,
                FileDataId = 9,
                Type = FileTypeEnum.Estimate,
            },


            new FileEntity()
            {
                Id = 10,
                Name = "potreba.txt",
                Number = "ID_12",
                MIME = "text/plain",
                WorkflowId = 4,
                Version = 1,
                FileDataId = 10,
                Type = FileTypeEnum.Assignment,
            },
            new FileEntity()
            {
                Id = 11,
                Name = "schvaleni.txt",
                Number = "ID_13",
                MIME = "text/plain",
                WorkflowId = 4,
                Version = 1,
                FileDataId = 11,
                Type = FileTypeEnum.Acceptation,
            },


            new FileEntity()
            {
                Id = 12,
                Name = "zadani.txt",
                Number = "ID_18",
                MIME = "text/plain",
                WorkflowId = 5,
                Version = 1,
                FileDataId = 12,
                Type = FileTypeEnum.Assignment,
            },
            new FileEntity()
            {
                Id = 13,
                Name = "zadani.txt",
                Number = "ID_18",
                MIME = "text/plain",
                WorkflowId = 5,
                Version = 2,
                FileDataId = 13,
                Type = FileTypeEnum.Assignment,
            },
            new FileEntity()
            {
                Id = 14,
                Name = "zadani.txt",
                Number = "ID_18",
                MIME = "text/plain",
                WorkflowId = 5,
                Version = 3,
                FileDataId = 14,
                Type = FileTypeEnum.Assignment,
            },
            new FileEntity()
            {
                Id = 15,
                Name = "schvaleni.txt",
                Number = "ID_19",
                MIME = "text/plain",
                WorkflowId = 5,
                Version = 1,
                FileDataId = 15,
                Type = FileTypeEnum.Acceptation,
            },
            new FileEntity()
            {
                Id = 16,
                Name = "schvaleni.txt",
                Number = "ID_19",
                MIME = "text/plain",
                WorkflowId = 5,
                Version = 2,
                FileDataId = 16,
                Type = FileTypeEnum.Acceptation,
            },
            new FileEntity()
            {
                Id = 27,
                Name = "smlouva.txt",
                Number = "ID_20",
                MIME = "text/plain",
                WorkflowId = 5,
                Version = 1,
                FileDataId = 27,
                Type = FileTypeEnum.Contract,
            },


            new FileEntity()
            {
                Id = 17,
                Name = "abcd.txt",
                Number = "ID_189",
                MIME = "text/plain",
                WorkflowId = 6,
                Version = 1,
                FileDataId = 17,
                Type = FileTypeEnum.Assignment,
            },
            new FileEntity()
            {
                Id = 18,
                Name = "efgh.txt",
                Number = "ID_191",
                MIME = "text/plain",
                WorkflowId = 6,
                Version = 1,
                FileDataId = 18,
                Type = FileTypeEnum.Acceptation,
            },
            new FileEntity()
            {
                Id = 19,
                Name = "ijkl.txt",
                Number = "ID_193",
                MIME = "text/plain",
                WorkflowId = 6,
                Version = 1,
                FileDataId = 19,
                Type = FileTypeEnum.Contract,
            },
            new FileEntity()
            {
                Id = 26,
                Name = "nopl.txt",
                Number = "ID_194",
                MIME = "text/plain",
                WorkflowId = 6,
                Version = 1,
                FileDataId = 26,
                Type = FileTypeEnum.Estimate,
            },


            new FileEntity()
            {
                Id = 20,
                Name = ":D.txt",
                Number = "EDDDQ",
                MIME = "text/plain",
                WorkflowId = 6,
                Version = 2,
                FileDataId = 20,
                Type = FileTypeEnum.Assignment,
            },
            new FileEntity()
            {
                Id = 21,
                Name = ":).txt",
                Number = "EAAAQ",
                MIME = "text/plain",
                WorkflowId = 6,
                Version = 2,
                FileDataId = 21,
                Type = FileTypeEnum.Acceptation,
            },
            new FileEntity()
            {
                Id = 22,
                Name = ":-).txt",
                Number = "EEEEQ",
                MIME = "text/plain",
                WorkflowId = 6,
                Version = 2,
                FileDataId = 22,
                Type = FileTypeEnum.Contract,
            },
            new FileEntity()
            {
                Id = 23,
                Name = ";).txt",
                Number = "EEEEQ",
                MIME = "text/plain",
                WorkflowId = 6,
                Version = 3,
                FileDataId = 23,
                Type = FileTypeEnum.Contract,
            },
            new FileEntity()
            {
                Id = 24,
                Name = ":0.txt",
                Number = "AEQQQ",
                MIME = "text/plain",
                WorkflowId = 6,
                Version = 2,
                FileDataId = 24,
                Type = FileTypeEnum.Estimate,
            },
            new FileEntity()
            {
                Id = 25,
                Name = ":].txt",
                Number = "VVQQQ",
                MIME = "text/plain",
                WorkflowId = 6,
                Version = 1,
                FileDataId = 25,
                Type = FileTypeEnum.Publication,
            },


            new FileEntity()
            {
                Id = 28,
                Name = "fakt to potrebujeme.txt",
                Number = "2434",
                MIME = "text/plain",
                WorkflowId = 7,
                Version = 1,
                FileDataId = 28,
                Type = FileTypeEnum.Assignment,
            },
            new FileEntity()
            {
                Id = 29,
                Name = "ale opravdu to potrebujeme.txt",
                Number = "2434",
                MIME = "text/plain",
                WorkflowId = 7,
                Version = 2,
                FileDataId = 29,
                Type = FileTypeEnum.Assignment,
            },
            new FileEntity()
            {
                Id = 30,
                Name = "tak si to kupte.txt",
                Number = "2435",
                MIME = "text/plain",
                WorkflowId = 7,
                Version = 1,
                FileDataId = 30,
                Type = FileTypeEnum.Acceptation,
            },


            new FileEntity()
            {
                Id = 31,
                Name = "hulky!!.txt",
                Number = "2435",
                MIME = "text/plain",
                WorkflowId = 8,
                Version = 1,
                FileDataId = 31,
                Type = FileTypeEnum.Assignment,
            },
        };

        public static void SeedFiles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileEntity>().HasData(_files);
        }
    }
}
