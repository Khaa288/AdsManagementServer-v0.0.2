using AdsManagement.BuildingBlocks.Domain.Domain.Entities;

namespace AdsManagement.Modules.Report.Domain.Entities;

public class ReportImage : Entity
{
    public Guid ImageId { get; set; }
     public string Url { get; set; }
     
     public Guid ReportId { get; set; }
     public Report Report { get; set; }
 }