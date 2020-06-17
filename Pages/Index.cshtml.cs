using ExpensasAbbinatura.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace ExpensasAbbinatura.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        private readonly ExpensasAbbinatura.Models.ExpensasContext _context;

        public IndexModel(ILogger<IndexModel> logger, ExpensasAbbinatura.Models.ExpensasContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IEnumerable<Installment> Installments { get; set; }

        IEnumerable<Installment> GetInstallments(int personID)
        {
            var person = _context.Persons
                .Include(x => x.Installments)
                    .ThenInclude(x => x.InstallmentConcepts)
                    .ThenInclude(x => x.Concept)
                    .ThenInclude(x => x.ConceptType)
                .Include(x => x.Installments)
                    .ThenInclude(x => x.Status)
                .SingleOrDefault(x => x.PersonID == personID);

            if (person == null) { return new List<Installment>(); }

            return person.Installments
                .OrderByDescending(x => x.When);
        }

        public void OnGet()
        {
            Installments = GetInstallments(1);
        }
    }
}
