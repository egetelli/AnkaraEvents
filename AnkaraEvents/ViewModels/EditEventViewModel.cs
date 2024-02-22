using AnkaraEvents.Data;
using AnkaraEvents.Models;

namespace AnkaraEvents.ViewModels
{
    public class EditEventViewModel
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string? URL { get; set; }
        public int AddressId { get; set; }
        public Address EventAddress { get; set; }
        public DateTime Date { get; set; }
        public IFormFile Image { get; set; }
        public EventCategory EventCategory { get; set; }
    }
}
