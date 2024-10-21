using AdsManagement.BuildingBlocks.Domain.Domain.Entities;

namespace AdsManagement.Modules.Auth.Domain.Entities;

public class Officer : Entity
{
    public Guid OfficerId { get; set; }
    public string? FullName { get; set; }
    public DateTime DoB { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PasswordHash { get; set; }
    public Role Role { get; set; }
    public Guid RoleId { get; set; }
    public List<Privilege> Privileges { get; set; }
    public List<Otp> Otps { get; set; }
}