namespace AdsManagement.BuildingBlocks.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    // private readonly IDomainEventsDispatcher _domainEventsDispatcher;

    public UnitOfWork(
        DbContext context
        // IDomainEventsDispatcher domainEventsDispatcher
    )
    {
        this._context = context;
        // this._domainEventsDispatcher = domainEventsDispatcher;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        // await this._domainEventsDispatcher.DispatchEventsAsync();

        return await _context.SaveChangesAsync(cancellationToken);
    }
}