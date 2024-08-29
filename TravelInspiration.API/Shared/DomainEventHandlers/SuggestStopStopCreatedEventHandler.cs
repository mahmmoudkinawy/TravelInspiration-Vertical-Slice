using MediatR;
using TravelInspiration.API.Shared.Domain.Entities;
using TravelInspiration.API.Shared.Events;
using TravelInspiration.API.Shared.Persistence;

namespace TravelInspiration.API.Shared.DomainEventHandlers;

public sealed class SuggestStopStopCreatedEventHandler(TravelInspirationDbContext dbContext, ILogger<SuggestStopStopCreatedEventHandler> logger)
	: INotificationHandler<StopCreatedEvent>
{
	private readonly TravelInspirationDbContext _dbContext = dbContext;
	private readonly ILogger<SuggestStopStopCreatedEventHandler> _logger = logger;

	public Task Handle(StopCreatedEvent notification, CancellationToken cancellationToken)
	{
		_logger.LogInformation("Listener {listener} to domain event {domainEvent} triggered", GetType().Name, notification.GetType().Name);

		var incomingStop = notification.Stop;

		var stop = new Stop($"AI-ified stop based on {incomingStop.Name}")
		{
			ItineraryId = incomingStop.ItineraryId,
			ImageUri = new Uri("https://herebeimages.ciom/aigeneratedimage.png"),
			Suggested = true
		};

		_dbContext.Stops.Add(stop);

		return Task.CompletedTask;
	}
}
