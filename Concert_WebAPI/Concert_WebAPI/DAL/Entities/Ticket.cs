using System.ComponentModel.DataAnnotations;

namespace Concert_WebAPI.DAL.Entities
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime? UseDate { get; set; }

        public Boolean IsUsed { get; set; }

        [MaxLength(100)]
        public string? EntraceGate { get; set; }
    }
}
