using AnkaraEvents.Data;
using AnkaraEvents.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Detail(int id)
        {
            Event oneevent = _context.Events.Include(a => a.EventAddress).FirstOrDefault(e => e.Id == id);
            return View(oneevent);
        }
    }
}
