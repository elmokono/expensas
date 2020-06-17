using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExpensasAbbinatura.Models;

namespace ExpensasAbbinatura.Pages.Concepts
{
    public class DetailsModel : PageModel
    {
        private readonly ExpensasAbbinatura.Models.ExpensasContext _context;

        public DetailsModel(ExpensasAbbinatura.Models.ExpensasContext context)
        {
            _context = context;
        }

        public Concept Concept { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Concept = await _context.Concepts.Include(x => x.ConceptType).FirstOrDefaultAsync(m => m.ConceptID == id);

            if (Concept == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
