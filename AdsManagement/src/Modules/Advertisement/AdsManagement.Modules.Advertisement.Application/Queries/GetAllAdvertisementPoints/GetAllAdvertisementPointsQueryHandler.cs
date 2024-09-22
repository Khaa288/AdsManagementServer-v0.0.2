using AdsManagement.Modules.Advertisement.Application.Configuration.Queries;
using AdsManagement.Modules.Advertisement.Domain.Entities;
using AdsManagement.Modules.Advertisement.Domain.Repositories;

namespace AdsManagement.Modules.Advertisement.Application.Queries;

public class GetAllAdvertisementPointsQueryHandler : IQueryHandler<GetAllAdvertisementPointsQuery, List<AdvertisementPoint>>
{
    private readonly IAdvertisementPointRepository _advertisementPointRepository;

    public GetAllAdvertisementPointsQueryHandler(IAdvertisementPointRepository advertisementPointRepository)
    {
        _advertisementPointRepository = advertisementPointRepository;
    }

    public async Task<List<AdvertisementPoint>> Handle(GetAllAdvertisementPointsQuery request, CancellationToken cancellationToken)
    {
        return await _advertisementPointRepository.GetAllAdvertisementPoints();
    }
}