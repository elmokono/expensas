using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExpensasAbbinatura.Models;

namespace ExpensasAbbinatura.Pages.LivingUnits
{
    public class IndexModel : PageModel
    {
        private readonly ExpensasAbbinatura.Models.ExpensasContext _context;

        public IndexModel(ExpensasAbbinatura.Models.ExpensasContext context)
        {
            _context = context;
        }

        public LivingUnit LivingUnit { get;set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            LivingUnit = await _context.LivingUnits
                .Include(x => x.Building)
                .Include(x => x.Persons)
                .FirstAsync(x => x.LivingUnitId == id);

            if (LivingUnit == null) { return new NotFoundResult(); }

            return Page();
        }
    }
}
