using AdsManagement.Modules.Advertisement.Application.Configuration.Queries;
using AdsManagement.Modules.Advertisement.Domain.Entities;
using AdsManagement.Modules.Advertisement.Domain.Repositories;

namespace AdsManagement.Modules.Advertisement.Application.Queries;

public class GetWardAdvertisementPointsQueryHandler : IQueryHandler<GetWardAdvertisementPointsQuery, List<AdvertisementPoint>>
{
    private readonly IAdvertisementPointRepository _advertisementPointRepository;

    public GetWardAdvertisementPointsQueryHandler(IAdvertisementPointRepository advertisementPointRepository)
    {
        _advertisementPointRepository = advertisementPointRepository;
    }
    
    public async Task<List<AdvertisementPoint>> Handle(GetWardAdvertisementPointsQuery request, CancellationToken cancellationToken)
    {
        return await _advertisementPointRepository.GetAdvertisementPointsByWardId(request.WardId);
    }
}