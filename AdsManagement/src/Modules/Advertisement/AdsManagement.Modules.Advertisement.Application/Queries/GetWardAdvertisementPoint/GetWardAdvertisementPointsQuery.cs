using AdsManagement.Modules.Advertisement.Application.Contracts;
using AdsManagement.Modules.Advertisement.Domain.Entities;

namespace AdsManagement.Modules.Advertisement.Application.Queries;

public class GetWardAdvertisementPointsQuery : QueryBase<List<AdvertisementPoint>>
{
    public int WardId { get; set; }

    public GetWardAdvertisementPointsQuery(int wardId)
    {
        WardId = wardId;
    }
}