﻿//=================================================================================================================
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

namespace itu.DAL.Entities
{
    public class ModelTaskEntity
    {
        public int Id { get; set; }
        public TaskTypeEnum Type { get; set; }
        public int Difficulty { get; set; }
        public List<ModelWorkflowTaskEntity> WorkflowTasks { get; set; }
    }
}
