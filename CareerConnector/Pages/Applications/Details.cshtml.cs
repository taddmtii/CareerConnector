using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CareerConnector.Models;

namespace CareerConnector.Pages.Applications
{
    public class DetailsModel : PageModel
    {
        private readonly CareerConnector.Models.ccContext _context;

        public DetailsModel(CareerConnector.Models.ccContext context)
        {
            _context = context;
        }

        public Application Application { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications.FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (application == null)
            {
                return NotFound();
            }
            else
            {
                Application = application;
            }
            return Page();
        }
    }
}
