using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CareerConnector.Models;
using System.Security.Claims;

namespace CareerConnector.Pages.Jobs
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
            var UserEmail = @User.FindFirstValue(ClaimTypes.Email);
            var isEmployer = _context.Employers
                .Where(e => e.Email == UserEmail)
                .ToList();
            ViewData["EmployerId"] = new SelectList(isEmployer, "EmployerId", "EmployerId");
            return Page();
        }

        [BindProperty]
        public Job Job { get; set; } = default!;
        public Employer Employer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (Job.Employer == null)
            {
                Job.Employer = _context.Employers.Where(x => x.EmployerId == Job.EmployerId).FirstOrDefault();
                ModelState.Clear();
                TryValidateModel(Job);
            }
            if (!ModelState.IsValid || _context.Jobs == null || Job == null)
            {
                return Page();
            }

            _context.Jobs.Add(Job);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}