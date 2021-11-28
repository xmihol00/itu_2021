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

namespace itu.BL.DTOs.Task
{
    public class OverviewDTO
    {
        public List<AllTaskDTO> Tasks { get; set; }
        public DetailTaskDTO Detail { get; set; }
        public int Selected { get; set; }
    }
}
