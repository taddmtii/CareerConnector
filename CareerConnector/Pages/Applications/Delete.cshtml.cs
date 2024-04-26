﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CareerConnector.Models;

namespace CareerConnector.Pages.Applications
{
    public class DeleteModel : PageModel
    {
        private readonly CareerConnector.Models.ccContext _context;

        public DeleteModel(CareerConnector.Models.ccContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications.FindAsync(id);
            if (application != null)
            {
                Application = application;
                _context.Applications.Remove(Application);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
