using AdsManagement.BuildingBlocks.Domain.Domain.Entities;

namespace AdsManagement.Modules.Advertisement.Domain.Entities;

public class MaptilerEntity : Entity
{
    public string MaptilerId { get; set; }
    public string Feature { get; set; }
    public string Type { get; set; }
}