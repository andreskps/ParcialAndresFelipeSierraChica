using Concert_WebAPI.DAL.Entities;

namespace Concert_WebAPI.DAL
{
    public class SeederDb
    {
        private readonly DBContext _context;

        public SeederDb(DBContext context)
        {
            _context = context;
        }

        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await PopulateTicketsAsync();
            await _context.SaveChangesAsync();

        }

        private async Task PopulateTicketsAsync()
        {
            if (!_context.Tickets.Any())
            {
                for (int i = 0; i < 50000; i++)
                {
                    Ticket ticket = new Ticket
                    {

                        Id = Guid.NewGuid(),
                        IsUsed = false,
                        UseDate = null,
                        EntraceGate = null
                    };

                    _context.Tickets.Add(ticket);
                }

            }
        }
    }
}
