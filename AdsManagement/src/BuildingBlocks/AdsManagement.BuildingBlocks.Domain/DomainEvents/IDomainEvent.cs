using MediatR;

namespace AdsManagement.BuildingBlocks.Domain.DomainEvents;

public interface IDomainEvent
{
    Guid Id { get; }

    DateTime CreatedAt { get; }
}