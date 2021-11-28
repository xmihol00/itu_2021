//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       David Mihola
// Kontakt:     xmihol00@stud.fit.vutbr.cz
//=================================================================================================================

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
    public class AccountController : Controller
    {
        private readonly UserFacade _facade;

        public AccountController(UserFacade facade)
        {
            _facade = facade;
        }

        [HttpGet]
        public IActionResult SignIn(string ReturnURL, string UserName)
        {
            return View(new SignInDTO(){ UserName = UserName, ReturnURL = ReturnURL });
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
                return RedirectToAction(nameof(SignIn), new { model.ReturnURL, model?.UserName });
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
