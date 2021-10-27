using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace itu.WEB.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            ClaimsPrincipal user = HttpContext.User;

            ViewBag.Name = user.Identity.Name;
            ViewBag.Id = 0;
            ViewBag.Signed = user.Identity.IsAuthenticated;

            List<Claim> claims = user.Claims?.ToList();
            if (claims != null)
            {
                foreach(Claim claim in claims)
                {
                    if (claim.Type == ClaimTypes.NameIdentifier)
                    {
                        ViewBag.Id = Int32.Parse(claim.Value);
                    }
                }
            }
        }
    }
}
