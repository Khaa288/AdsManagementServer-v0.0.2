using AdsManagement.BuildingBlocks.Domain.Domain.Entities;

namespace AdsManagement.Modules.Auth.Domain.Entities;

public class Privilege : Entity
{
    public Guid PrivilegeId { get; set; }
    public string PrivilegeName { get; set; }
    
    public List<Role> Roles { get; set; }
    public List<Officer> Officers { get; set; }
}