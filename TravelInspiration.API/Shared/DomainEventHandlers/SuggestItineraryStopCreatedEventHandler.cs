﻿using MediatR;
using TravelInspiration.API.Shared.Events;

namespace TravelInspiration.API.Shared.DomainEventHandlers;

public sealed class SuggestItineraryStopCreatedEventHandler(ILogger<SuggestItineraryStopCreatedEventHandler> logger)
	: INotificationHandler<StopCreatedEvent>
{
	private readonly ILogger<SuggestItineraryStopCreatedEventHandler> _logger = logger;

	public Task Handle(StopCreatedEvent notification, CancellationToken cancellationToken)
	{
		_logger.LogInformation("Listener {listener} to domain event {domainEvent} triggered", GetType().Name, notification.GetType().Name);

		return Task.CompletedTask;
	}
}
