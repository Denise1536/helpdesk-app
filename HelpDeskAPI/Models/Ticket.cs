using System;
using System.Collections.Generic;

namespace HelpDeskAPI.Models;

public partial class Ticket
{
    public int IdTicket { get; set; }

    public string Title { get; set; } = null!;

    public string Details { get; set; } = null!;

    public string? Resolution { get; set; }

    public DateTime DateOpened { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? ResolvedBy { get; set; }

    public DateTime? DateClosed { get; set; }

    public DateTime? LastOpened { get; set; }

    public bool? Status { get; set; }

    public bool? Favorites { get; set; }
}
