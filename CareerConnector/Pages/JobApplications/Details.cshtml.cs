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
    public class DetailsModel : PageModel
    {
        private readonly CareerConnector.Models.ccContext _context;

        public DetailsModel(CareerConnector.Models.ccContext context)
        {
            _context = context;
        }

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
    }
}
