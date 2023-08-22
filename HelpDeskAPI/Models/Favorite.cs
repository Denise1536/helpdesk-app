using System;
using System.Collections.Generic;

namespace HelpDeskAPI.Models;

public partial class Favorite
{
    public int? IdTicket { get; set; }

    public int? IdUser { get; set; }

    public bool? Favorite1 { get; set; }

    public virtual Ticket? IdTicketNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
