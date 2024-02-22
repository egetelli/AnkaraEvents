using AnkaraEvents.Models;

namespace AnkaraEvents.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event> GetByIdAsync(int id);
        Task<Event> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Event>> GetEventByCity(string city);
        bool Add(Event anevent);
        bool Update(Event anevent);
        bool Delete(Event anevent);
        bool Save();
    }
}
