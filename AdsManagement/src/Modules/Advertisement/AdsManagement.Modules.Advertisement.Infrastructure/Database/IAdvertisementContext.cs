using MongoDB.Driver;

namespace AdsManagement.Modules.Advertisement.Infrastructure.Database;

public interface IAdvertisementContext
{
    IMongoDatabase Database { get; }
}