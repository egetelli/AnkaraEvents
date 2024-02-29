using AnkaraEvents.Data;
using AnkaraEvents.Models;

namespace AnkaraEvents.ViewModels
{
    public class CreateEventViewModel
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public Address EventAddress { get; set; }
        public DateTime Date { get; set; }
        public IFormFile Image { get; set; }
        public EventCategory EventCategory { get; set; }
        public string AppUserId { get; set; }
    }
}
