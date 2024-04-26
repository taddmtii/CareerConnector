using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CareerConnector.Models;

namespace CareerConnector.Pages.JobApplications
{
    public class DeleteModel : PageModel
    {
        private readonly CareerConnector.Models.ccContext _context;

        public DeleteModel(CareerConnector.Models.ccContext context)
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

            var jobapplication = await _context.JobApplications.FirstOrDefaultAsync(m => m.JobId == id);

            if (jobapplication == null)
            {
                return NotFound();
            }
            else
            {
                JobApplication = jobapplication;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobapplication = await _context.JobApplications.FindAsync(id);
            if (jobapplication != null)
            {
                JobApplication = jobapplication;
                _context.JobApplications.Remove(JobApplication);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
