using AdsManagement.Modules.Advertisement.Application.Caching;

using System.Text.Json;

namespace AdsManagement.Modules.Advertisement.Infrastructure.Caching;

public class CachingService : ICachingService
{
    private readonly ICachingDatabase _database;

    public CachingService(ICachingDatabase database)
    {
        _database = database;
    }

    public async Task<T?> GetData<T>(string key)
    {
        var value = await _database.Cache.StringGetAsync(key);
        return !string.IsNullOrEmpty(value) ? JsonSerializer.Deserialize<T>(value) : default;
    }

    public async Task<bool> SetData<T>(string key, T value, DateTimeOffset expirationTime)
    {
        var expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
        return await _database.Cache.StringSetAsync(key, JsonSerializer.Serialize(value), expiryTime);
    }
}