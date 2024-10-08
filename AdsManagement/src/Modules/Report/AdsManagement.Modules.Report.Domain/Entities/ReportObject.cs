using AdsManagement.BuildingBlocks.Domain.Domain.Entities;

namespace AdsManagement.Modules.Report.Domain.Entities;

public class ReportObject : Entity
{
    public int SurrogateKey { get; set; }
    public Guid ObjectId { get; set; }
    public string ObjectType { get; set; }
    public string Address { get; set; }
    public string DistrictName { get; set; }
    public string WardName { get; set; }
    
    public List<Report> Reports { get; set; }
}