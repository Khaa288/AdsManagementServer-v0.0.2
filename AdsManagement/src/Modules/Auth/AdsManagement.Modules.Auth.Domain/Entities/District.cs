namespace AdsManagement.Modules.Auth.Domain.Entities;

public class District
{
    public int DistrictId { get; set; }
    public string DistrictName { get; set; }
    
    public List<Ward> Wards { get; set; }
}