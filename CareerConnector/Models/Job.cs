using System;
using System.Collections.Generic;

namespace CareerConnector.Models;

public partial class Job
{
    public int JobId { get; set; }

    public int EmployerId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Pay { get; set; } = null!;

    public string JobType { get; set; } = null!;

    public virtual Employer Employer { get; set; } = null!;
}
