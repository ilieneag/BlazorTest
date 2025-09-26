using EventEase.Models;

namespace EventEase.Services;

public interface IEventService
{
    Task<IEnumerable<Event>> GetEventsAsync();
    Task<Event?> GetEventAsync(int id);
}

public class EventService : IEventService
{
    private readonly List<Event> _events = new()
    {
        new Event { Id = 1, Name = "Tech Summit 2025", Date = DateTime.Today.AddDays(10), Location = "New York", Description = "Annual technology summit with industry leaders." },
        new Event { Id = 2, Name = "Corporate Retreat", Date = DateTime.Today.AddDays(25), Location = "Denver", Description = "Team building and strategy planning retreat." },
        new Event { Id = 3, Name = "Product Launch Expo", Date = DateTime.Today.AddDays(40), Location = "San Francisco", Description = "Showcase of new product line and demos." }
    };

    public Task<IEnumerable<Event>> GetEventsAsync() => Task.FromResult<IEnumerable<Event>>(_events);

    public Task<Event?> GetEventAsync(int id) => Task.FromResult(_events.FirstOrDefault(e => e.Id == id));
}
