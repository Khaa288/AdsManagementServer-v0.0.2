using AdsManagement.Modules.Advertisement.Domain.Entities;
using AdsManagement.Modules.Advertisement.Infrastructure.Domain.Entities;
using MongoDB.Driver;

namespace AdsManagement.Modules.Advertisement.Infrastructure.Database;

public class AdvertisementContext : IAdvertisementContext
{
    public IMongoDatabase Database { get; }
    
    public IMongoCollection<AdvertisementPoint> AdvertisementPointCollection;
    public IMongoCollection<AdvertisementBoard> AdvertisementBoardCollection;
    public IMongoCollection<Ward> WardCollection;
    public IMongoCollection<District> DistrictCollection;

    public AdvertisementContext(DatabaseConfiguration configuration)
    {
        var client = new MongoClient(configuration.ConnectionString);
        Database = client.GetDatabase(configuration.DatabaseName);
        
        ConfigureEntities();
        
        AdvertisementPointCollection = Database.GetCollection<AdvertisementPoint>(nameof(AdvertisementPoint), settings: new MongoCollectionSettings());
        AdvertisementBoardCollection = Database.GetCollection<AdvertisementBoard>(nameof(AdvertisementBoard));
        WardCollection = Database.GetCollection<Ward>(nameof(Ward));
        DistrictCollection = Database.GetCollection<District>(nameof(District));
    }

    private void ConfigureEntities()
    {
        AdvertisementPointConfiguration.AddMapping();
    }
}