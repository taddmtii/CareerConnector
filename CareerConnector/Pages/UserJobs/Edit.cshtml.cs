using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareerConnector.Models;

namespace CareerConnector.Pages.UserJobs
{
    public class EditModel : PageModel
    {
        private readonly CareerConnector.Models.ccContext _context;

        public EditModel(CareerConnector.Models.ccContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserJob UserJob { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userjob =  await _context.UserJobs.FirstOrDefaultAsync(m => m.UserId == id);
            if (userjob == null)
            {
                return NotFound();
            }
            UserJob = userjob;
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

            _context.Attach(UserJob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserJobExists(UserJob.UserId))
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

        private bool UserJobExists(string id)
        {
            return _context.UserJobs.Any(e => e.UserId == id);
        }
    }
}
