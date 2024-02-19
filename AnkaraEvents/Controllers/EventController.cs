using Microsoft.AspNetCore.Mvc;

namespace AnkaraEvents.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
