namespace AdsManagement.Modules.Auth.Domain.Entities;

public class Ward
{
    public int WardId { get; set; }
    public string WardName { get; set; }
    
    public int DistrictId { get; set; }
    public District District { get; set; }
    public Officer Officer { get; set; }
}