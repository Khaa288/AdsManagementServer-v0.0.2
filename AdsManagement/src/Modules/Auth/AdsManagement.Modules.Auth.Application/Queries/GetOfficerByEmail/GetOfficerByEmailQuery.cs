using AdsManagement.Modules.Auth.Application.Contracts;
using AdsManagement.Modules.Auth.Domain.Entities;

namespace AdsManagement.Modules.Auth.Application.Queries;

public class GetOfficerByEmailQuery : QueryBase<Officer>
{
    public string Email { get; }

    public GetOfficerByEmailQuery(string email)
    {
        Email = email;
    }
}