using AdsManagement.Modules.Advertisement.Application.Contracts;
using AdsManagement.Modules.Advertisement.Domain.Entities;

namespace AdsManagement.Modules.Advertisement.Application.Queries;

public class GetAdvertisementPointQuery : QueryBase<AdvertisementPoint>
{
    public Guid PointId { get; }

    public GetAdvertisementPointQuery(Guid pointId)
    {
        PointId = pointId;
    }
}