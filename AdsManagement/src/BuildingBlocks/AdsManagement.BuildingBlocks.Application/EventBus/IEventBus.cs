namespace AdsManagement.BuildingBlocks.Application.EventBus;

public interface IEventBus
{
    Task Publish<T>(T @event, CancellationToken cancellationToken = default) where T : class;
}