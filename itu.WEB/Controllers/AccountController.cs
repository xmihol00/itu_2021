using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using itu.BL.DTOs.Account;
using itu.BL.Facades;
using itu.Common.Helpers;
using itu.DAL.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace itu.WEB.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserFacade _facade;

        public AccountController(UserFacade facade, BaseFacade baseFacade) : base(baseFacade)
        {
            _facade = facade;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View(new SignInDTO());
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDTO model)
        {
            try
            {
                UserEntity user = await _facade.Authenticate(model);
                ClaimsPrincipal principal = SignInHelper.CreateSignIn(user.Id, user.FirstName, user.LastName);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return Redirect(model.ReturnURL ?? "/");
            }
            catch
            {
                return RedirectToAction(nameof(SignIn), new { model.ReturnURL });
            }
        }

        [HttpGet]
        [Route("/Account/SignOut")]
        public async Task<IActionResult> Signout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }


        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
