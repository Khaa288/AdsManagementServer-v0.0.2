using AdsManagement.BuildingBlocks.Application.Common.Files;
using AdsManagement.Modules.Report.Application.Contracts;

namespace AdsManagement.Modules.Report.Application.Commands;

public class SendReportCommand : CommandBase<SendReportResponse?>
{
    public string ReporterName { get; }
    public string ReporterEmail { get; }
    public string ReporterPhoneNumber { get; }
    public string ReportType { get; }
    public string Content { get; }
    public Guid ReportObjectId { get; }
    public string ReportObjectType { get; }
    public ICollection<FileData> Images { get; }
    public string ReCaptchaResponseToken { get; }

    public SendReportCommand(
        string reporterName, 
        string reporterEmail, 
        string reporterPhoneNumber, 
        string reportType, 
        string content, 
        Guid reportObjectId,
        string reportObjectType,
        ICollection<FileData> images, 
        string reCaptchaResponseToken)
    {
        ReporterName = reporterName;
        ReporterEmail = reporterEmail;
        ReporterPhoneNumber = reporterPhoneNumber;
        ReportObjectId = reportObjectId;
        ReportObjectType = reportObjectType;
        ReportType = reportType;
        Content = content;
        Images = images;
        ReCaptchaResponseToken = reCaptchaResponseToken;
    }
}