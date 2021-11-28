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
using itu.DAL.Repositories;

namespace itu.BL.Facades
{
    public class BaseFacade
    {
        private readonly TaskRepository _repository;
        
        public BaseFacade(TaskRepository repository)
        {
            _repository = repository;
        }

        public int TaskOfUserCount(int userId)
        {
            return _repository.TaskOfUserCount(userId);
        }
    }
}
