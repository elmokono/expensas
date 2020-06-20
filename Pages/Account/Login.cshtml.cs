using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ExpensasAbbinatura.Pages.Security
{
    public class AccountModel : PageModel
    {
        private readonly ExpensasAbbinatura.Security.IUserManager _userManager;

        public AccountModel(ExpensasAbbinatura.Security.IUserManager userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public ExpensasAbbinatura.Models.Person Person { get; set; }

        [BindProperty]
        public string ReturnUrl { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                //authenticate
                var user = new ExpensasAbbinatura.Models.Person()
                {
                    Email = Person.Email,
                    FullName = Person.FullName,
                    Department = Person.Department
                };

                var signedIn = (await _userManager.SignIn(this.HttpContext, user));

                if (!signedIn) throw new Exception("Authentication failed");

                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("summary", ex.Message);
                return Page();
            }
        }
    }
}