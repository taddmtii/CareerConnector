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
    public class IndexModel : PageModel
    {
        private readonly CareerConnector.Models.ccContext _context;

        public IndexModel(CareerConnector.Models.ccContext context)
        {
            _context = context;
        }

        public IList<UserJob> UserJob { get;set; } = default!;

        public async Task OnGetAsync()
        {
            UserJob = await _context.UserJobs.ToListAsync();
        }
    }
}
