using AdsManagement.BuildingBlocks.Application.Common.Filters;
using AdsManagement.BuildingBlocks.Application.Common.Pagination;
using AdsManagement.Modules.Advertisement.Application.Configuration.Queries;
using AdsManagement.Modules.Advertisement.Domain.Entities;
using AdsManagement.Modules.Advertisement.Domain.Repositories;

namespace Application.Queries.GetAdvertisementPointsPagin;

public class GetAdvertisementPointsPaginQueryHandler : IQueryHandler<GetAdvertisementPointsPaginQuery, PagedList<AdvertisementPoint>>
{
    private readonly IAdvertisementPointRepository _advertisementPointRepository;

    public GetAdvertisementPointsPaginQueryHandler(IAdvertisementPointRepository advertisementPointRepository)
    {
        _advertisementPointRepository = advertisementPointRepository;
    }
    
    public async Task<PagedList<AdvertisementPoint>> Handle(GetAdvertisementPointsPaginQuery request, CancellationToken cancellationToken)
    {
        var conditions = new Dictionary<string, object>();

        if (request.LocationType != null)
        {
            conditions.Add(nameof(request.LocationType), request.LocationType);
        }

        if (request.AdvertisingForm != null)
        {
            conditions.Add(nameof(request.AdvertisingForm), request.AdvertisingForm);
        }
        
        var filter = FilterUtils<AdvertisementPoint>.CreateEqualFilter(conditions);
        
        var (points, count) = await _advertisementPointRepository.GetPaginAdvertisementPoints(request.PageNumber, request.PageSize, filter);
        return new PagedList<AdvertisementPoint>(points, count, request.PageNumber, request.PageSize);
    }
}