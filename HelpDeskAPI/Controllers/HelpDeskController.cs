using HelpDeskAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

namespace HelpDeskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpDeskController : ControllerBase
    {
        private readonly HelpDeskDbContext _dbContext;

        public HelpDeskController(HelpDeskDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Ticket>> GetTickets()
        {
            return _dbContext.Tickets.ToList();
        }

        [HttpGet("{idTicket}")]
        public ActionResult<Ticket> GetTicket(int idTicket)
        {
            var ticket = _dbContext.Tickets.Find(idTicket);
      //we edited the two lines below 8.24
            if (ticket != null) { return ticket; }
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateTicket([FromBody] Ticket ticket)
        {
            _dbContext.Tickets.Add(ticket);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetTicket), new { id = ticket.IdTicket }, ticket);
        }

        [HttpPut("{idTicket}")]
        public IActionResult CloseTicket(int idTicket, [FromBody] Ticket updatedTicket)
        {
            var ticket = _dbContext.Tickets.Find(idTicket);
            if (ticket == null) { return NotFound(); }
            ticket.Resolution = updatedTicket.Resolution;
            ticket.ResolvedBy = updatedTicket.ResolvedBy;
            ticket.DateClosed = updatedTicket.DateClosed;
            ticket.Status = updatedTicket.Status;
            _dbContext.Tickets.Update(ticket);
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpPut("{Favorite1}")]
        public IActionResult AddFavorite(int idTicket, [FromBody] Favorite addFavorite)
        {
            var favorite = _dbContext.Favorites.Find(idTicket);
            if (idTicket == null) { return NotFound(); }
            favorite.Favorite1 = addFavorite.Favorite1;
            _dbContext.Favorites.Update(favorite);
            _dbContext.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{Favorite1}")]
        public IActionResult DeleteFavorite(int idTicket, [FromBody] Favorite deleteFavorite)
        {
            var favorite = _dbContext.Favorites.Find(idTicket);
            if (idTicket == null) { return NotFound(); }
            favorite.Favorite1 = deleteFavorite.Favorite1;
            _dbContext.Favorites.Update(favorite);
            _dbContext.SaveChanges();
            return NoContent();

        }

        [HttpGet("{GetFavorites}")]
        public ActionResult<IEnumerable<Favorite>> GetFavorites()
        {
            return _dbContext.Favorites.ToList();
        }


    }
}
