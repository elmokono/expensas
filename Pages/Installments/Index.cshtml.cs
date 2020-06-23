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
    public class IndexModel : PageModel
    {
        private readonly ExpensasAbbinatura.Models.ExpensasContext _context;

        public IndexModel(ExpensasAbbinatura.Models.ExpensasContext context)
        {
            _context = context;
        }

        public IEnumerable<Installment> Installments { get; set; }

        public IEnumerable<int> Years
        {
            get
            {
                for (int i = DateTime.Now.Year; i > 2018; i--)
                {
                    yield return i;
                }

            }
        }

        [BindProperty]
        public int SelectedYear { get; set; }

        [BindProperty]
        public bool ClassicView { get; set; }

        public async Task OnPostAsync()
        {
            Installments = await GetInstallments().ToListAsync();
        }

        public async Task OnGetAsync()
        {
            SelectedYear = Years.First();
            ClassicView = false;
            Installments = await GetInstallments().ToListAsync();
        }

        IOrderedQueryable<Installment> GetInstallments()
        {
            return _context.Installments
                .AsNoTracking()
                .Include(x => x.InstallmentConcepts)
                    .ThenInclude(x => x.Concept)
                    .ThenInclude(x => x.ConceptType)
                .Include(x => x.Status)
                .Include(x => x.Person)
                .Where(x => x.Person.Email == User.FindFirst(System.Security.Claims.ClaimTypes.Email).Value)
                .Where(x => x.When.Year == SelectedYear)
                .OrderBy(x => x.When);
        }

    }
}
