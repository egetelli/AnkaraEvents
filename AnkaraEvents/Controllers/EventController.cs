using AnkaraEvents.Data;
using AnkaraEvents.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnkaraEvents.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Event> events = _context.Events.ToList();
            return View(events);
        }
    }
}
