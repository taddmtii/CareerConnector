using System.Collections.Generic;
using System.Linq;
using CareerConnector.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CareerConnector.Pages
{
    public class SearchModel : PageModel
    {
        private readonly ccContext _context;

        public SearchModel(ccContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public List<Job> SearchResults { get; set; }

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                //retrieves job records from database
                SearchResults = _context.Jobs
                    //Load Employer entity for each job
                    .Include(j => j.Employer)
                    //filters job records based on if the searchterm is within the title or description
                    .Where(j => EF.Functions.Like(j.Title, $"%{SearchTerm}%") ||
                                EF.Functions.Like(j.Description, $"%{SearchTerm}%") ||
                                EF.Functions.Like(j.City, $"%{SearchTerm}%") ||
                                EF.Functions.Like(j.State, $"%{SearchTerm}%") ||
                                EF.Functions.Like(j.Employer.Company, $"%{SearchTerm}%")
                                )
                    .ToList();
            }
        }
    }
}