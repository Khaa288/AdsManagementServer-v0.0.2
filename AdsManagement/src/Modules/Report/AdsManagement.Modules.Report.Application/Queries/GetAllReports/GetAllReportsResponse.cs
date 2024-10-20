namespace AdsManagement.Modules.Report.Application.Queries;

public class GetAllReportsResponse
{
    public Guid ReportId { get; set; }
    public string ReportType { get; set; }
    public string Content { get; set; }
    public string Solution { get; set; }
    public int Status { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string ObjectType { get; set; }
    public string Address { get; set; }
    public string DistrictName { get; set; }
    public string WardName { get; set; }
}