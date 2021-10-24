using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itu.BL.DTOs.Account;
using itu.BL.Facades;
using Microsoft.AspNetCore.Mvc;

namespace itu.WEB.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserFacade _facade;

        public AccountController(UserFacade facade)
        {
            _facade = facade;
        }

        public async Task<IActionResult> SignIn()
        {
            return View(new SignInDTO());
        }
    }
}
