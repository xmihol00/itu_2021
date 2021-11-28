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

namespace itu.DAL.Entities.Tasks.Interfaces
{
    public interface IEstimateEntity : ITaskEntity 
    {
        public double EstimatePrice { get; set; }
        public double MaxPrice { get; set; }
    }
}
