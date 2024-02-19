using System.ComponentModel.DataAnnotations;

namespace AnkaraEvents.Models
{
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }
        public int EventId { get; set; }
        public bool IsAttending { get; set; }
        public Address Address { get; set; }
        public ICollection<Event> Events { get; set; }

    }
}
