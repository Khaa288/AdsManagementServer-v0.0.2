using StackExchange.Redis;

namespace AdsManagement.Modules.Advertisement.Infrastructure.Caching;

public interface ICachingDatabase
{
    IDatabase Cache { get; }
}