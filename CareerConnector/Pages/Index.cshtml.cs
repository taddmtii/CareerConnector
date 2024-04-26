using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CareerConnector.Areas.Identity.Data;
using CareerConnector.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace CareerConnector.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ccContext _context;


        public List<Job> jobs { get; set; } = default!;

        public List<Job> favorites { get; set; } = default!;

        public List<Employer> isEmployer { get; set; } = default!;

        public IndexModel(ILogger<IndexModel> logger, ccContext context)
        {
            _logger = logger;
            _context = context;

        }

        public void OnGet()
        {
            jobs = _context.Jobs
                .Include("Employer")
                .OrderBy(x => x.Employer.Company)
                .ToList();

            var UserId = @User.FindFirstValue(ClaimTypes.NameIdentifier);
            favorites = _context.UserJobs
                .Where(uj => uj.UserId == UserId)
                .Select(uj => uj.Job)
                .ToList();

            var UserEmail = @User.FindFirstValue(ClaimTypes.Email);
            isEmployer = _context.Employers
                .Where(e => e.Email == UserEmail)
                .ToList();

        }


        public void OnPost(int JobId)
        {

            var UserId = @User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!_context.UserJobs.Any(uj => uj.UserId == UserId && uj.JobId == JobId))
            {
                _context.UserJobs.Add(new UserJob { UserId = UserId, JobId = JobId });
                _context.SaveChanges();
            }
            favorites = _context.UserJobs
                .Where(uj => uj.UserId == UserId)
                .Select(uj => uj.Job)
                .ToList();
            jobs = _context.Jobs
                .Include("Employer")
                .OrderBy(x => x.Employer.Company)
                .ToList();
            var UserEmail = @User.FindFirstValue(ClaimTypes.Email);
            isEmployer = _context.Employers
                .Where(e => e.Email == UserEmail)
                .ToList();

        }

        public void OnPostDelete(int JobId)
        {
            var UserId = @User.FindFirstValue(ClaimTypes.NameIdentifier);

            var userJob = _context.UserJobs.FirstOrDefault(uj => uj.UserId == UserId && uj.JobId == JobId);

            if (userJob != null)
            {
                _context.UserJobs.Remove(userJob);
                _context.SaveChanges();
            }
            favorites = _context.UserJobs
                .Where(uj => uj.UserId == UserId)
                .Select(uj => uj.Job)
                .ToList();
            jobs = _context.Jobs
                .Include("Employer")
                .OrderBy(x => x.Employer.Company)
                .ToList();
            var UserEmail = @User.FindFirstValue(ClaimTypes.Email);
            isEmployer = _context.Employers
                .Where(e => e.Email == UserEmail)
                .ToList();

        }
    }
}