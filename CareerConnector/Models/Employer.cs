using System;
using System.Collections.Generic;

namespace CareerConnector.Models;

public partial class Employer
{
    public int EmployerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Company { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
