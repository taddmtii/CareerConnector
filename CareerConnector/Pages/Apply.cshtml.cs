using CareerConnector.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace CareerConnector.Pages
{
    public class ApplyModel : PageModel
    {
        private readonly ccContext _context;

        public ApplyModel(ccContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string UserId { get; set; }

        [BindProperty, Required]
        public string Company { get; set; }

        [BindProperty, Required]
        public string FirstName { get; set; }

        [BindProperty, Required]
        public string LastName { get; set; }

        [BindProperty, Required, EmailAddress]
        public string Email { get; set; }

        [BindProperty, Required]
        public string Skills { get; set; }

        [BindProperty]
        public IFormFile Resume { get; set; }

        public IActionResult OnPost(int JobId)
        {
            var UserId = @User.FindFirstValue(ClaimTypes.NameIdentifier);
            byte[] resumeData = null;
            if (Resume != null && Resume.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    Resume.CopyToAsync(memoryStream);
                    resumeData = memoryStream.ToArray();
                }
            }

            var application = new Application
            {
                UserId = UserId,
                Company = Company,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Skills = Skills,
                Resume = resumeData
            };
            _context.Applications.Add(application);
            _context.SaveChanges();

            var jobApplication = new JobApplication
            {
                JobId = JobId,
                ApplicationId = application.ApplicationId
            };
            _context.JobApplications.Add(jobApplication);
            _context.SaveChanges();
            return Redirect("/AppFinished");

        }
        public void OnGet(int JobId)
        {
            Console.WriteLine("This is the JobId lmfao: " + JobId);
        }

    }
}