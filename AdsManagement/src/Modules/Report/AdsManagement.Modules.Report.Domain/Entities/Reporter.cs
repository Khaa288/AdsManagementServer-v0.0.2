using AdsManagement.BuildingBlocks.Domain.Domain.Entities;

namespace AdsManagement.Modules.Report.Domain.Entities;

public class Reporter : Entity
{
    public Guid ReporterId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    
    public List<Report> Reports { get; set; }
}