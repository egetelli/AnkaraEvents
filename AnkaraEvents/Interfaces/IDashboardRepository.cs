using AnkaraEvents.Models;

namespace AnkaraEvents.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Event>> GetAllUserEvents();

    }
}
