using AdsManagement.Modules.Advertisement.Application.Caching;
using AdsManagement.Modules.Advertisement.Application.Configuration.Queries;
using AdsManagement.Modules.Advertisement.Application.Constraints.Constants;
using AdsManagement.Modules.Advertisement.Application.Constraints.Enums;
using AdsManagement.Modules.Advertisement.Domain.Entities;
using AdsManagement.Modules.Advertisement.Domain.Repositories;

namespace AdsManagement.Modules.Advertisement.Application.Queries;

public class GetAllAdvertisementPointsQueryHandler : IQueryHandler<GetAllAdvertisementPointsQuery, List<AdvertisementPoint>>
{
    private readonly IAdvertisementPointRepository _advertisementPointRepository;
    private readonly ICachingService _cachingService;

    public GetAllAdvertisementPointsQueryHandler(IAdvertisementPointRepository advertisementPointRepository, ICachingService cachingService)
    {
        _advertisementPointRepository = advertisementPointRepository;
        _cachingService = cachingService;
    }

    public async Task<List<AdvertisementPoint>> Handle(GetAllAdvertisementPointsQuery request, CancellationToken cancellationToken)
    {
        var cachedPoints = await _cachingService.GetData<List<AdvertisementPoint>>(CacheKey.ADVERTISEMENT_POINT);
        if (cachedPoints != null && cachedPoints.Count() > 0)
        {
            return cachedPoints;
        }
        
        var points = await _advertisementPointRepository.GetAllAdvertisementPoints();
        var expirtyTime = DateTimeOffset.Now.AddHours((int)CacheExpiryTime.OneDay);
        await _cachingService.SetData<List<AdvertisementPoint>>(CacheKey.ADVERTISEMENT_POINT, points, expirtyTime);
        return points;
    }
}