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
    public class IndexModel : PageModel
    {
        private readonly ExpensasAbbinatura.Models.ExpensasContext _context;

        public IndexModel(ExpensasAbbinatura.Models.ExpensasContext context)
        {
            _context = context;
        }

        public IList<Concept> Concept { get;set; }

        public async Task OnGetAsync()
        {
            Concept = await _context.Concepts.Include(x => x.ConceptType).ToListAsync();
        }
    }
}
