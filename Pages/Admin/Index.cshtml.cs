using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ExpensasAbbinatura.Pages.Admin
{
    [Authorize(Roles = "ADMIN")]
    public class IndexModel : PageModel
    {
        private readonly ExpensasAbbinatura.Models.ExpensasContext _context;

        public IndexModel(ExpensasAbbinatura.Models.ExpensasContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int SelectedBuildingId { get; set; }

        public IEnumerable<ExpensasAbbinatura.Models.Building> Buildings { get; set; }
        public IEnumerable<ExpensasAbbinatura.Models.Person> Persons { get; set; }

        public async Task OnGetAsync()
        {
            SelectedBuildingId = _context.Buildings.OrderBy(x => x.Name).First().BuildingId;
            await Bind();
        }

        public async Task OnPostAsync()
        {
            await Bind();
        }

        async Task Bind()
        {
            Buildings = await _context.Buildings.ToListAsync();
            Persons = await _context.Persons
                .Include(x => x.Installments)
                .ThenInclude(x => x.InstallmentConcepts)
                .Include(x => x.Installments)
                .ThenInclude(x => x.Status)
                .Where(x => x.Building.BuildingId == SelectedBuildingId)
                .ToListAsync();
        }
    }
}