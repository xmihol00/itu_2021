using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace itu.Common.Helpers
{
    public static class SignInHelper
    {
        public static ClaimsPrincipal CreateSignIn(int id, string firstName, string lastName)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Name, $"{firstName} {lastName}"),
            };

            ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");

            return new ClaimsPrincipal(userIdentity);
        }
    }
}
