using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using itu.DAL.Repositories;

namespace itu.BL.Facades
{
    public class UserFacade
    {
        private readonly UserRepository _repository;
        private readonly IMapper _mapper;

        public UserFacade(UserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
