using AdsManagement.Modules.Auth.Application.Contracts;
using AdsManagement.Modules.Auth.Domain.Entities;

namespace AdsManagement.Modules.Auth.Application.Commands;

public class CreateOfficerCommand : CommandBase
{
    public string Email { get; }
    public string FullName { get; }
    public DateTime DoB { get; }
    public string? PhoneNumber { get; }
    public string Password { get; }
    public string RePassword { get; }
    public int? WardId { get; }
    public int DistrictId { get; }
    public Guid RoleId { get; }
    public List<Privilege> Privileges { get; set; }

    public CreateOfficerCommand(string email, string fullName, DateTime doB, string? phoneNumber, string password, string rePassword, int? wardId, int districtId, Guid roleId, List<Privilege> privileges)
    {
        Email = email;
        FullName = fullName;
        DoB = doB;
        PhoneNumber = phoneNumber;
        Password = password;
        RePassword = rePassword;
        WardId = wardId;
        DistrictId = districtId;
        RoleId = roleId;
        Privileges = privileges;
    }
}
