using System;
using System.Collections.Generic;

namespace CareerConnector.Models;

public partial class JobApplication
{
    public int JobId { get; set; }

    public Job Job { get; set; }

    public int ApplicationId { get; set; }

    public Application Application { get; set; }
}
