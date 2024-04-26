using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareerConnector.Models;

namespace CareerConnector.Pages.Jobs
{
    public class EditModel : PageModel
    {
        private readonly CareerConnector.Models.ccContext _context;

        public EditModel(CareerConnector.Models.ccContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Job Job { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job =  await _context.Jobs.FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }
            Job = job;
           ViewData["EmployerId"] = new SelectList(_context.Employers, "EmployerId", "EmployerId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}


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


            _context.Attach(Job).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(Job.JobId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Index");
        }

        private bool JobExists(int id)
        {
            return _context.Jobs.Any(e => e.JobId == id);
        }
    }
}
