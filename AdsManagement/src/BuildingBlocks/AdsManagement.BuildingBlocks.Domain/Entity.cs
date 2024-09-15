using AdsManagement.BuildingBlocks.Domain.DomainEvents;

namespace AdsManagement.BuildingBlocks.Domain;

public class Entity
{
    private List<IDomainEvent> _domainEvents;
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }
    
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        this._domainEvents.Add(domainEvent);
    }
}