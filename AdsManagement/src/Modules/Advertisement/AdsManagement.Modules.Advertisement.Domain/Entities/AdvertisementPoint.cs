using AdsManagement.BuildingBlocks.Domain.Domain.Entities;
using AdsManagement.Modules.Advertisement.Domain.ValueObjects;

namespace AdsManagement.Modules.Advertisement.Domain.Entities;
public class AdvertisementPoint : Entity
{
    public Guid PointId { get; set; }
    public string Address { get; set; }
    public string LocationType { get; set; }
    public string AdvertisingForm { get; set; }
    public bool IsPlanned { get; set; } 
    public List<string> Images { get; set; } = new List<string>();
    
    public DistrictBase District { get; set; }
    public WardBase Ward { get; set; }
    public Coordinate Coordinates { get; set; }
}