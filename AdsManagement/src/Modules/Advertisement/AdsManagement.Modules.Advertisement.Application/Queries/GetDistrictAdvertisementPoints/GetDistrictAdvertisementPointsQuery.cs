using AdsManagement.Modules.Advertisement.Application.Contracts;
using AdsManagement.Modules.Advertisement.Domain.Entities;

namespace AdsManagement.Modules.Advertisement.Application.Queries;

public class GetDistrictAdvertisementPointsQuery : QueryBase<List<AdvertisementPoint>>
{
    public int DistrictId { get; set; }

    public GetDistrictAdvertisementPointsQuery(int districtId)
    {
        DistrictId = districtId;
    }
}