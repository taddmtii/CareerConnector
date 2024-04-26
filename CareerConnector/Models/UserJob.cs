using System;
using System.Collections.Generic;

namespace CareerConnector.Models;

public partial class UserJob
{
    public string UserId { get; set; } = null!;
    public User User { get; set; }

    public int JobId { get; set; }
    public Job Job { get; set; }
}
