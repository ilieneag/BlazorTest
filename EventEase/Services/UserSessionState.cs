using EventEase.Models;

namespace EventEase.Services;

/// <summary>
/// Simple per-user (per Blazor circuit) session state container.
/// Stores lightweight, non-sensitive session data for the current visitor.
/// </summary>
public class UserSessionState
{
    public Guid SessionId { get; } = Guid.NewGuid();
    public DateTime CreatedAtUtc { get; } = DateTime.UtcNow;

    private readonly HashSet<int> _registeredEventIds = new();
    public IReadOnlyCollection<int> RegisteredEventIds => _registeredEventIds;

    public Event? LastViewedEvent { get; private set; }
    public Event? LastRegisteredEvent { get; private set; }

    public int RegistrationCount => _registeredEventIds.Count;

    public event Action? OnChange;

    public void SetLastViewedEvent(Event ev)
    {
        LastViewedEvent = ev;
        Notify();
    }

    public void RegisterEvent(Event ev)
    {
        if (_registeredEventIds.Add(ev.Id))
        {
            LastRegisteredEvent = ev;
            Notify();
        }
    }

    private void Notify() => OnChange?.Invoke();
}