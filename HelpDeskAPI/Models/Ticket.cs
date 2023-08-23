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
}


public static class TicketEndpoints
{
	public static void MapTicketEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Ticket", () =>
        {
            return new [] { new Ticket() };
        })
        .WithName("GetAllTickets");

        routes.MapGet("/api/Ticket/{id}", (int id) =>
        {
            //return new Ticket { ID = id };
        })
        .WithName("GetTicketById");

        routes.MapPut("/api/Ticket/{id}", (int id, Ticket input) =>
        {
            return Results.NoContent();
        })
        .WithName("UpdateTicket");

        routes.MapPost("/api/Ticket/", (Ticket model) =>
        {
            //return Results.Created($"//api/Tickets/{model.ID}", model);
        })
        .WithName("CreateTicket");

        routes.MapDelete("/api/Ticket/{id}", (int id) =>
        {
            //return Results.Ok(new Ticket { ID = id });
        })
        .WithName("DeleteTicket");
    }
}