using CareerConnector.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CareerConnector.Pages
{
    public class ViewApplicationsModel : PageModel
    {
        public readonly ccContext _context;

        public List<Application> applications { get; set; }

        public ViewApplicationsModel(ccContext context)
        {
            _context = context;
            applications = new List<Application>(); 
        }

        public void OnGet(int JobId)
        {
            var jobs = _context.JobApplications
                .Where(a => a.JobId == JobId)
                .ToList();

            Console.WriteLine("Job Count " + jobs.Count());
            Console.WriteLine(JobId);

            foreach (var job in jobs)
            {
                var application = _context.Applications.FirstOrDefault(a => a.ApplicationId == job.ApplicationId);
                if (application != null)
                {
                    Console.WriteLine("Application is " + application.Email);
                    applications.Add(application); // Add to the property instead of a local variable
                }
            }
        }
    }
}