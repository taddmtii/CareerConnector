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
    public class IndexModel : PageModel
    {
        private readonly CareerConnector.Models.ccContext _context;

        public IndexModel(CareerConnector.Models.ccContext context)
        {
            _context = context;
        }

        public IList<Job> Job { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Job = await _context.Jobs
                .Include(j => j.Employer).ToListAsync();
        }
    }
}
