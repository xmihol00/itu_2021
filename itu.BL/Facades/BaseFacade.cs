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
