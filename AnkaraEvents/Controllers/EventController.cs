using AnkaraEvents.Data;
using AnkaraEvents.Interfaces;
using AnkaraEvents.Models;
using AnkaraEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AnkaraEvents.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly IPhotoService _photoService;

        public EventController(IEventRepository eventRepository, IPhotoService photoService)
        {
            _eventRepository = eventRepository;
            _photoService = photoService;
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
        public async Task<IActionResult> Create(CreateEventViewModel eventVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(eventVM.Image);

                var _event = new Event
                {
                    EventName = eventVM.EventName,
                    Description = eventVM.Description,
                    Image = result.Url.ToString(),
                    Date = eventVM.Date,
                    EventAddress = new Address
                    {
                        City = eventVM.EventAddress.City,
                        Street = eventVM.EventAddress.Street,
                        District = eventVM.EventAddress.District
                    }
                    
                };
                _eventRepository.Add(_event);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(eventVM);
           
        }
    }
}
