using AnkaraEvents.Data;
using AnkaraEvents.Interfaces;
using AnkaraEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AnkaraEvents.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<IActionResult> Index()
        {
            var userEvents = await _dashboardRepository.GetAllUserEvents();
            var dashboardViewModel = new DashboardViewModel()
            {
                Events = userEvents
            };
            return View(dashboardViewModel);
        }
    }
}
