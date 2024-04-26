using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CareerConnector.Models;

namespace CareerConnector.Pages.Employers
{
    public class DeleteModel : PageModel
    {
        private readonly CareerConnector.Models.ccContext _context;

        public DeleteModel(CareerConnector.Models.ccContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employer Employer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employer = await _context.Employers.FirstOrDefaultAsync(m => m.EmployerId == id);

            if (employer == null)
            {
                return NotFound();
            }
            else
            {
                Employer = employer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employer = await _context.Employers.FindAsync(id);
            if (employer != null)
            {
                Employer = employer;
                _context.Employers.Remove(Employer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
