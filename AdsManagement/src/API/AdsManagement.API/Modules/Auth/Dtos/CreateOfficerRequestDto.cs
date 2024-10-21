namespace AdsManagement.API.Modules.Auth.Dtos;

public class CreateOfficerRequestDto
{
    public string Email { get; set; }
    public string FullName { get; set; }
    public DateTime DoB { get; set; }
    public string? PhoneNumber { get; set; }
    public string Password { get; set; }
    public string RePassword { get; set; }
    public int WardId { get; set; }
    public int DistrictId { get; set; }
    public Guid RoleId { get; set; }
    public List<Guid> Privileges { get; set; }
}