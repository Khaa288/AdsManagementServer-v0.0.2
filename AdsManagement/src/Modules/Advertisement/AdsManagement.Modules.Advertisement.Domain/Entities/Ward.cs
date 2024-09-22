namespace AdsManagement.Modules.Advertisement.Domain.Entities;

public class Ward : MaptilerEntity
{
    public int WardId { get; set; }
    public string WardName { get; set; }
    public int DistrictId { get; set; }
}