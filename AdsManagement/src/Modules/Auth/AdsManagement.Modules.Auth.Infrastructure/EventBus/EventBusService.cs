using AdsManagement.BuildingBlocks.Application.EventBus;

using MassTransit;

namespace AdsManagement.Modules.Auth.Infrastructure.EventBus;

public class EventBusService : IEventBus
{
    private readonly IPublishEndpoint _publishEndpoint;

    public EventBusService(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task Publish<T>(T @event, CancellationToken cancellationToken = default)
        where T : class
    {
        await _publishEndpoint.Publish<T>(@event, cancellationToken);
    }
}
