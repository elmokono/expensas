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
    public class DeleteModel : PageModel
    {
        private readonly ExpensasAbbinatura.Models.ExpensasContext _context;

        public DeleteModel(ExpensasAbbinatura.Models.ExpensasContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Concept Concept { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Concept = await _context.Concepts.FirstOrDefaultAsync(m => m.ConceptID == id);

            if (Concept == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Concept = await _context.Concepts.FindAsync(id);

            if (Concept != null)
            {
                _context.Concepts.Remove(Concept);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
