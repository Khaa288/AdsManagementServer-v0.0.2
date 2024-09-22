using AdsManagement.Modules.Advertisement.Application.Configuration.Queries;
using AdsManagement.Modules.Advertisement.Domain.Entities;
using AdsManagement.Modules.Advertisement.Domain.Repositories;

namespace AdsManagement.Modules.Advertisement.Application.Queries;

public class GetAdvertisementPointQueryHandler : IQueryHandler<GetAdvertisementPointQuery, AdvertisementPoint>
{
    private readonly IAdvertisementPointRepository _advertisementPointRepository;

    public GetAdvertisementPointQueryHandler(IAdvertisementPointRepository advertisementPointRepository)
    {
        _advertisementPointRepository = advertisementPointRepository;
    }

    public async Task<AdvertisementPoint> Handle(GetAdvertisementPointQuery request, CancellationToken cancellationToken)
    {
        return await _advertisementPointRepository.GetAdvertisementPointByPointId(request.PointId);
    }
}