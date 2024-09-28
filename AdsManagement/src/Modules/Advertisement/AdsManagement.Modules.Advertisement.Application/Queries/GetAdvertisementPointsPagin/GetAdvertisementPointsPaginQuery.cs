using AdsManagement.BuildingBlocks.Application.Common.Pagination;
using AdsManagement.Modules.Advertisement.Application.Contracts;
using AdsManagement.Modules.Advertisement.Domain.Entities;

namespace Application.Queries.GetAdvertisementPointsPagin;

public class GetAdvertisementPointsPaginQuery : QueryBase<PagedList<AdvertisementPoint>>
{
    public int PageNumber { get; }
    public int PageSize { get; }
    public string? LocationType { get; }
    public string? AdvertisingForm { get; }
    public bool IsPlanned { get; }

    public GetAdvertisementPointsPaginQuery(int pageNumber, int pageSize, string? locationType, string? advertisingForm, bool isPlanned)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        LocationType = locationType;
        AdvertisingForm = advertisingForm;
        IsPlanned = isPlanned;
    }
}