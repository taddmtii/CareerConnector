using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CareerConnector.Models;

namespace CareerConnector.Pages.JobApplications
{
    public class CreateModel : PageModel
    {
        private readonly CareerConnector.Models.ccContext _context;

        public CreateModel(CareerConnector.Models.ccContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public JobApplication JobApplication { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.JobApplications.Add(JobApplication);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
