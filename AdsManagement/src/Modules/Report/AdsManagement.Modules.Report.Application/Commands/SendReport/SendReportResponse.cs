using AdsManagement.Modules.Report.Application.Constraints.Enums;

namespace AdsManagement.Modules.Report.Application.Commands;

public class SendReportResponse
{
    public Guid ReportId { get; set; }
    public string ReportType { get; set; }
    public string Content { get; set; }
    public ReportStatus Status { get; set; }
    public DateTime CreatedTime { get; set; }
    public string ObjectType { get; set; }
    public string Address { get; set; }
    public string DistrictName { get; set; }
    public string WardName { get; set; }
    public string ReporterName { get; set; }
    public string ReporterEmail { get; set; }
    public string ReporterPhoneNumber { get; set; }
}