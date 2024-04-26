using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareerConnector.Models;

namespace CareerConnector.Pages.JobApplications
{
    public class EditModel : PageModel
    {
        private readonly CareerConnector.Models.ccContext _context;

        public EditModel(CareerConnector.Models.ccContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JobApplication JobApplication { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobapplication =  await _context.JobApplications.FirstOrDefaultAsync(m => m.JobId == id);
            if (jobapplication == null)
            {
                return NotFound();
            }
            JobApplication = jobapplication;
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

            _context.Attach(JobApplication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobApplicationExists(JobApplication.JobId))
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

        private bool JobApplicationExists(int id)
        {
            return _context.JobApplications.Any(e => e.JobId == id);
        }
    }
}
