namespace AdsManagement.API.Modules.Advertisement.Dtos;

public class AdvertisementPointQueryRequestDto : PaginationRequestDto
{
    public string? LocationType { get; set; }
    public string? AdvertisingForm { get; set; }
    public bool IsPlanned { get; set; }
}