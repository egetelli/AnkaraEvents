using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnkaraEvents.Models
{
    public class AppUser : IdentityUser
    {
        
        public int EventId { get; set; }
        public bool IsAttending { get; set; }
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? EventAddress { get; set; }
        public ICollection<Event> Events { get; set; }

    }
}
