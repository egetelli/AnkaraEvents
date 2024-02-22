using AnkaraEvents.Data;
using AnkaraEvents.Interfaces;
using AnkaraEvents.Models;
using Microsoft.EntityFrameworkCore;

namespace AnkaraEvents.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Event anevent)
        {
            _context.Add(anevent);
            return Save();
        }

        public bool Delete(Event anevent)
        {
            _context.Remove(anevent);
            return Save();
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            return await _context.Events.Include(i => i.EventAddress).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Event> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Events.Include(i => i.EventAddress).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Event>> GetEventByCity(string city)
        {
            return await _context.Events.Where(c => c.EventAddress.City.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
           var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Event anevent)
        {
            _context.Update(anevent);
            return Save();
        }
    }
}
