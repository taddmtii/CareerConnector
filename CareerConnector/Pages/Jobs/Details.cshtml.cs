using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CareerConnector.Models;

namespace CareerConnector.Pages.Jobs
{
    public class DetailsModel : PageModel
    {
        private readonly CareerConnector.Models.ccContext _context;

        public DetailsModel(CareerConnector.Models.ccContext context)
        {
            _context = context;
        }

        public Job Job { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs.FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }
            else
            {
                Job = job;
            }
            return Page();
        }
    }
}
