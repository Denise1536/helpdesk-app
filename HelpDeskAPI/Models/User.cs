using System;
using System.Collections.Generic;

namespace HelpDeskAPI.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }
}
