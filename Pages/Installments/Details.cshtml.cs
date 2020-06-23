using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExpensasAbbinatura.Models;

namespace ExpensasAbbinatura.Pages.Installments
{
    public class DetailsModel : PageModel
    {
        private readonly ExpensasAbbinatura.Models.ExpensasContext _context;

        public DetailsModel(ExpensasAbbinatura.Models.ExpensasContext context)
        {
            _context = context;
        }

        public Installment Installment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Installment = await _context.Installments
                .Include(x => x.InstallmentConcepts)
                .ThenInclude(x => x.Concept)
                .FirstOrDefaultAsync(m => m.InstallmentId == id);

            if (Installment == null)
            {
                return NotFound();
            }

            return new JsonResult(Installment);
        }
    }
}
