using TravelInspiration.API.Shared.Domain;
using TravelInspiration.API.Shared.Domain.Entities;

namespace TravelInspiration.API.Shared.Events;

public sealed class StopCreatedEvent(Stop stop) : DomainEvent
{
	public Stop Stop { get; } = stop;
}
