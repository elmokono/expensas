using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExpensasAbbinatura.Models;

namespace ExpensasAbbinatura.Pages.Persons
{
    public class DetailsModel : PageModel
    {
        private readonly ExpensasAbbinatura.Models.ExpensasContext _context;

        public DetailsModel(ExpensasAbbinatura.Models.ExpensasContext context)
        {
            _context = context;
        }

        public Person Person { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = await _context.Persons.FirstOrDefaultAsync(m => m.PersonID == id);

            if (Person == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
