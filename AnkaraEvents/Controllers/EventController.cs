using AnkaraEvents.Data;
using AnkaraEvents.Interfaces;
using AnkaraEvents.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AnkaraEvents.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;

        public EventController(ApplicationDbContext context, IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Event> events = await _eventRepository.GetAll();
            return View(events);
        }
        public async Task<IActionResult> Detail(int id)
        {
            Event oneevent = await _eventRepository.GetByIdAsync(id);
            return View(oneevent);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Event oneevent)
        {
            if (!ModelState.IsValid)
            {
                return View(oneevent);
            }
            _eventRepository.Add(oneevent);
            return RedirectToAction("Index");
        }
    }
}
