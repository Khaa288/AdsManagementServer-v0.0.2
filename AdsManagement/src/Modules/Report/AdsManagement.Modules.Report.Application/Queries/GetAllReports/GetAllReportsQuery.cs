using AdsManagement.Modules.Report.Application.Contracts;

namespace AdsManagement.Modules.Report.Application.Queries;

public class GetAllReportsQuery : QueryBase<IEnumerable<GetAllReportsResponse>>
{
    public string Name { get; }
    public string Email { get; }
    public string PhoneNumber { get; }

    public GetAllReportsQuery(string name, string email, string phoneNumber)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}