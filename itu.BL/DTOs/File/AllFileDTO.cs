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
using System.Threading.Tasks;
using itu.Common.Enums;
using Microsoft.AspNetCore.Http;

namespace itu.BL.DTOs.File
{
    public class AllFileDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int Version { get; set; }
        public FileTypeEnum Type { get; set; }
    }
}
