using AdsManagement.BuildingBlocks.Domain.DomainEntities;

namespace AdsManagement.Modules.Auth.Domain.Entities;

public class Role : Entity
{
    public Guid RoleId { get; set; }
    public string RoleName { get; set; }
    
    public Officer Officer { get; set; }
    public List<Privilege> Privileges { get; set; }
}