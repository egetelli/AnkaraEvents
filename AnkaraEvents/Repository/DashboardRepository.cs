using AnkaraEvents.Data;
using AnkaraEvents.Interfaces;
using AnkaraEvents.Models;

namespace AnkaraEvents.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public  async Task<List<Event>> GetAllUserEvents()
        {
            var curUser = _httpContextAccessor.HttpContext?.User;
            var userEvents = _context.Events.Where(r => r.AppUser.Id == curUser.ToString());
            return userEvents.ToList();
        }
    }
}
