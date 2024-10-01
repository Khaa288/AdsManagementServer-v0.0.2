using AdsManagement.Modules.Advertisement.Application.Configuration.Queries;
using AdsManagement.Modules.Advertisement.Domain.Entities;
using AdsManagement.Modules.Advertisement.Domain.Repositories;

namespace AdsManagement.Modules.Advertisement.Application.Queries;

public class GetDistrictAdvertisementPointsQueryHandler : IQueryHandler<GetDistrictAdvertisementPointsQuery, List<AdvertisementPoint>>
{
    private readonly IAdvertisementPointRepository _advertisementPointRepository;

    public GetDistrictAdvertisementPointsQueryHandler(IAdvertisementPointRepository advertisementPointRepository)
    {
        _advertisementPointRepository = advertisementPointRepository;
    }
    
    public async Task<List<AdvertisementPoint>> Handle(GetDistrictAdvertisementPointsQuery request, CancellationToken cancellationToken)
    {
        return await _advertisementPointRepository.GetAdvertisementPointsByDistrictId(request.DistrictId);
    }
}