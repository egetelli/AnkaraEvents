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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EventController(IEventRepository eventRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _eventRepository = eventRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
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
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var createEventViewModel = new CreateEventViewModel { AppUserId = curUserId };
            return View(createEventViewModel);
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
                    AppUserId = eventVM.AppUserId,
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

        public async Task<IActionResult> Edit(int id)
        {
            var oneevent = await _eventRepository.GetByIdAsync(id);
            if (oneevent == null) return View("Error");
            var eventVM = new EditEventViewModel
            {
                EventName = oneevent.EventName,
                Description = oneevent.Description,
                AddressId = oneevent.AddressId,
                EventAddress = oneevent.EventAddress,
                URL = oneevent.Image,
                EventCategory = oneevent.Category
            };
            return View(eventVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditEventViewModel eventVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit event");
                return View("Edit", eventVM);
            }
            var userEvent = await _eventRepository.GetByIdAsyncNoTracking(id);

            if (userEvent != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userEvent.Image);
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", "Could not delete photo");
                    return View(eventVM);
                }
                var photoResult = await _photoService.AddPhotoAsync(eventVM.Image);
                var _event = new Event
                {
                    Id = id,
                    EventName = eventVM.EventName,
                    Description = eventVM.Description,
                    Image = photoResult.Url.ToString(),
                    AddressId = eventVM.AddressId,
                    EventAddress = eventVM.EventAddress,
                    Date = eventVM.Date
                };

                _eventRepository.Update(_event);

                return RedirectToAction("Index");
            }
            else
            {
                return View(eventVM);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var eventDetails = await _eventRepository.GetByIdAsync(id);
            if (eventDetails == null) return View("Error");
            return View(eventDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var eventDetails = await _eventRepository.GetByIdAsync(id);
            if (eventDetails == null) return View("Error");

            _eventRepository.Delete(eventDetails);
            return RedirectToAction("Index");
        }
    }
}
