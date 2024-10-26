namespace AdsManagement.Modules.Auth.Domain.Entities;

public class WardOfficer : Officer
{
    public Ward Ward { get; set; }
    public int WardId { get; set; }
}
