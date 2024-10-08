using AdsManagement.BuildingBlocks.Domain.Domain.Entities;

namespace AdsManagement.Modules.Report.Domain.Entities;

public class Report : Entity
{
    public Guid ReportId { get; set; }
    public int ReportType { get; set; }
    public string Content { get; set; }
    public string Solution { get; set; }
    public int Status { get; set; }
    public DateTime CreatedTime { get; set; }
    
    public int ReportObjectId { get; set; }
    public ReportObject ReportObject { get; set; }
    
    public Guid ReporterId { get; set; }
    public Reporter Reporter { get; set; }
    
    public List<ReportImage> ReportImages { get; set; }
}