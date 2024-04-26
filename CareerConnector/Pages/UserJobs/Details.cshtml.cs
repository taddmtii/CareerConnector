using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CareerConnector.Models;

namespace CareerConnector.Pages.UserJobs
{
    public class DetailsModel : PageModel
    {
        private readonly CareerConnector.Models.ccContext _context;

        public DetailsModel(CareerConnector.Models.ccContext context)
        {
            _context = context;
        }

        public UserJob UserJob { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userjob = await _context.UserJobs.FirstOrDefaultAsync(m => m.UserId == id);
            if (userjob == null)
            {
                return NotFound();
            }
            else
            {
                UserJob = userjob;
            }
            return Page();
        }
    }
}
