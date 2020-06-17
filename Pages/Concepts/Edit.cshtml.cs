using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpensasAbbinatura.Models;

namespace ExpensasAbbinatura.Pages.Concepts
{
    public class EditModel : PageModel
    {
        private readonly ExpensasAbbinatura.Models.ExpensasContext _context;

        public EditModel(ExpensasAbbinatura.Models.ExpensasContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Concept).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConceptExists(Concept.ConceptID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ConceptExists(int id)
        {
            return _context.Concepts.Any(e => e.ConceptID == id);
        }
    }
}
