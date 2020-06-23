using ExpensasAbbinatura.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExpensasAbbinatura.Security
{
    public interface IUserManager
    {
        Task<bool> SignIn(HttpContext httpContext, ExpensasAbbinatura.Models.Person user, bool isPersistent = false);
        
        void SignOut(HttpContext httpContext);        
    }

    public class UserManager : IUserManager
    {
        private readonly ExpensasAbbinatura.Models.ExpensasContext _context;

        public UserManager(ExpensasAbbinatura.Models.ExpensasContext context)
        {
            _context = context;
        }

        public async Task<bool> SignIn(HttpContext httpContext, ExpensasAbbinatura.Models.Person user, bool isPersistent = false)
        {
            var dbUserData = _context.Persons.FirstOrDefault(x => x.Email == user.Email);

            if (dbUserData == null) return false;

            ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(dbUserData), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return true;
        }

        public async void SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }

        private IEnumerable<Claim> GetUserClaims(Person user)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.PersonId.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.FullName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.StreetAddress, user.Department));
            claims.AddRange(GetUserRoleClaims(user));

            return claims;
        }

        private IEnumerable<Claim> GetUserRoleClaims(ExpensasAbbinatura.Models.Person user)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.PersonId.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, user.RoleCode));
            return claims;
        }
    }
}
