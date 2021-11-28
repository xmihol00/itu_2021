﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.BL.DTOs.Agenda
{
    public class AllAgendaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<WorkflowCountDTO> Workflows { get; set; }
        public int UserCount { get; set; }
        public int NotFilledRoleCount { get; set; }
    }
}
