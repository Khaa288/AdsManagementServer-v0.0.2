using StackExchange.Redis;

namespace AdsManagement.Modules.Advertisement.Infrastructure.Caching;

public class CachingDatabase : ICachingDatabase
{
    public IDatabase Cache { get; }

    public CachingDatabase(string connectionString)
    {
        var redis = ConnectionMultiplexer.Connect(connectionString);
        Cache = redis.GetDatabase();
    }
}