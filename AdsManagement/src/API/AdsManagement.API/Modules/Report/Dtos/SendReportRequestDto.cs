﻿namespace AdsManagement.API.Modules.Report.Dtos;

public class SendReportRequestDto
{
    public string ReporterName { get; set; }
    public string ReporterEmail { get; set; }
    public string ReporterPhoneNumber { get; set; }
    public string Content { get; set; }
    public Guid ReportObjectId { get; set; }
    public string ReportObjectType { get; set; }
    public string ReportType { get; set; }
    public ICollection<IFormFile>? Images { get; set; }
    public string ReCaptchaResponseToken { get; set; }
}