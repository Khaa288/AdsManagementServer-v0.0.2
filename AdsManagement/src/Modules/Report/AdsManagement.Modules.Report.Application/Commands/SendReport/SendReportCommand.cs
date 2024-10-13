using AdsManagement.BuildingBlocks.Application.Common.Files;
using AdsManagement.Modules.Report.Application.Contracts;

namespace AdsManagement.Modules.Report.Application.Commands;

public class SendReportCommand : CommandBase<SendReportResponse>
{
    public string ReporterName { get; }
    public string ReporterEmail { get; }
    public string ReporterPhoneNumber { get; }
    public string ReportType { get; }
    public string Content { get; }
    public Guid ReportObjectId { get; }
    public ICollection<FileData> Images { get; }

    public SendReportCommand(
        string reporterName, 
        string reporterEmail, 
        string reporterPhoneNumber, 
        string reportType, 
        string content, 
        Guid reportObjectId,
        ICollection<FileData> images)
    {
        ReporterName = reporterName;
        ReporterEmail = reporterEmail;
        ReporterPhoneNumber = reporterPhoneNumber;
        ReportObjectId = reportObjectId;
        ReportType = reportType;
        Content = content;
        Images = images;
    }
}