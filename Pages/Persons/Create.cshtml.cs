using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpensasAbbinatura.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensasAbbinatura.Pages.Persons
{
    public class CreateModel : PageModel
    {
        private readonly ExpensasAbbinatura.Models.ExpensasContext _context;

        public CreateModel(ExpensasAbbinatura.Models.ExpensasContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Buildings = new SelectList(_context.Buildings.AsNoTracking().OrderBy(x => x.Name).AsNoTracking(), "BuildingId", "Name");
            return Page();
        }

        [BindProperty]
        public Person Person { get; set; }

        public SelectList Buildings { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Buildings = new SelectList(_context.Buildings.AsNoTracking().OrderBy(x => x.Name).AsNoTracking(), "BuildingId", "Name");
                return Page();
            }

            Person.Building = _context.Buildings.First(x => x.BuildingId == Person.Building.BuildingId);

            _context.Persons.Add(Person);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
