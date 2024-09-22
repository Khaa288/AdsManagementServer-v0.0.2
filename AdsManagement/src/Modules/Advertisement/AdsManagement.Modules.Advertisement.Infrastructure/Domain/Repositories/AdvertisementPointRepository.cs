using AdsManagement.Modules.Advertisement.Domain.Entities;
using AdsManagement.Modules.Advertisement.Domain.Repositories;
using AdsManagement.Modules.Advertisement.Infrastructure.Database;
using MongoDB.Driver;

namespace AdsManagement.Modules.Advertisement.Infrastructure.Domain.Repositories;

internal class AdvertisementPointRepository : IAdvertisementPointRepository
{
    private readonly AdvertisementContext _advertisementContext;

    public AdvertisementPointRepository(AdvertisementContext advertisementContext)
    {
        _advertisementContext = advertisementContext;
    }

    public async Task<List<AdvertisementPoint>> GetAllAdvertisementPoints()
    {
        var points =
            await _advertisementContext.AdvertisementPointCollection.Find(Builders<AdvertisementPoint>.Filter.Empty).ToListAsync();
        return points;
    }

    public Task<AdvertisementPoint> GetAdvertisementPointByPointId(Guid pointId)
    {
        throw new NotImplementedException();
    }

    public Task<List<AdvertisementPoint>> GetAdvertisementPointsByWardId(int wardId)
    {
        throw new NotImplementedException();
    }

    public Task<List<AdvertisementPoint>> GetAdvertisementPointsByDistrictId(int districtId)
    {
        throw new NotImplementedException();
    }
}