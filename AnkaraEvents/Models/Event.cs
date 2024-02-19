using AnkaraEvents.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnkaraEvents.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public EventCategory Category { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address EventAddress { get; set; }
        [ForeignKey("AppUser")]
        public int? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }



    }
}
