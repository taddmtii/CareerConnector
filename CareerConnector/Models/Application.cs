using System;
using System.Collections.Generic;

namespace CareerConnector.Models;

public partial class Application
{
    public int ApplicationId { get; set; }

    public string UserId { get; set; } = null!;

    public string Company { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Skills { get; set; } = null!;

    public byte[] Resume { get; set; } = null!;
}
