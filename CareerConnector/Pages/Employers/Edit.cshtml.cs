using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareerConnector.Models;

namespace CareerConnector.Pages.Employers
{
    public class EditModel : PageModel
    {
        private readonly CareerConnector.Models.ccContext _context;

        public EditModel(CareerConnector.Models.ccContext context)
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

            var employer =  await _context.Employers.FirstOrDefaultAsync(m => m.EmployerId == id);
            if (employer == null)
            {
                return NotFound();
            }
            Employer = employer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Employer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployerExists(Employer.EmployerId))
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

        private bool EmployerExists(int id)
        {
            return _context.Employers.Any(e => e.EmployerId == id);
        }
    }
}
