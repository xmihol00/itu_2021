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
using AutoMapper;
using itu.BL.DTOs.Account;
using itu.DAL.Entities;
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

        public Task<UserEntity> Authenticate(SignInDTO model)
        {
            return _repository.Authenticate(model.UserName, model.Password);
        }
    }
}
