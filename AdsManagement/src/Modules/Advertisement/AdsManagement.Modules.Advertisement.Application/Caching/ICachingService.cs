namespace AdsManagement.Modules.Advertisement.Application.Caching;

public interface ICachingService
{
    Task<T?> GetData<T>(string key);
    Task<bool> SetData<T>(string key, T data, DateTimeOffset expirationTime);
}