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
        return await _advertisementContext
            .AdvertisementPointCollection
            .Find(Builders<AdvertisementPoint>.Filter.Empty)
            .ToListAsync();
    }

    public async Task<AdvertisementPoint> GetAdvertisementPointByPointId(Guid pointId)
    {
        return await _advertisementContext.AdvertisementPointCollection
            .Find(filter: ap => ap.PointId.ToString() == pointId.ToString())
            .SingleOrDefaultAsync();
    }

    public async Task<List<AdvertisementPoint>> GetAdvertisementPointsByWardId(int wardId)
    {
        return await _advertisementContext.AdvertisementPointCollection
            .Find(filter: ap => ap.Ward.WardId == wardId)
            .ToListAsync();
    }

    public async Task<List<AdvertisementPoint>> GetAdvertisementPointsByDistrictId(int districtId)
    {
        return await _advertisementContext.AdvertisementPointCollection
            .Find(filter: ap => ap.District.DistrictId == districtId)
            .ToListAsync();
    }
}