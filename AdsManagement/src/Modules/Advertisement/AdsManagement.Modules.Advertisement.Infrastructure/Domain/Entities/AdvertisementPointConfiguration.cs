using AdsManagement.Modules.Advertisement.Domain.Entities;
using MongoDB.Bson.Serialization;

namespace AdsManagement.Modules.Advertisement.Infrastructure.Domain.Entities;

public static class AdvertisementPointConfiguration
{
    public static void AddMapping()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(AdvertisementPoint)))
        {
            BsonClassMap.RegisterClassMap<AdvertisementPoint>(classMap =>
            {
                classMap.SetIgnoreExtraElements(true);
                
                classMap.MapField(ap => ap.PointId);
                classMap.MapField(ap => ap.Address);
                classMap.MapField(ap => ap.LocationType);
                classMap.MapField(ap => ap.AdvertisingForm);
                classMap.MapField(ap => ap.IsPlanned);
                classMap.MapField(ap => ap.District);
                classMap.MapField(ap => ap.Ward);
                classMap.MapField(ap => ap.Coordinates);
            });
        }
    }
}