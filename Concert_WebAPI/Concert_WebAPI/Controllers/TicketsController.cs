using Concert_WebAPI.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Concert_WebAPI.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class TicketsController : ControllerBase
        {
            private readonly DBContext _context;

            public TicketsController(DBContext context)
            {
                _context = context;
            }

            [HttpPut, ActionName("Validate")]
            [Route("Validate/{id}/{entraceGate}")]
            public async Task<IActionResult> Put(Guid? id, string entraceGate)
            {
                var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
                if (ticket == null)
                {
                    return NotFound("Boleta no válida");
                }

                if (ticket.IsUsed)
                {

                    return BadRequest($"Boleta ya usada el {ticket.UseDate} en la {ticket.EntraceGate}");

                }
                ticket.UseDate = DateTime.Now;
                ticket.IsUsed = true;
                ticket.EntraceGate = entraceGate;

                _context.SaveChanges();

                return Ok("Boleta válida, puede ingresar al concierto");
            }



        }
    
}
