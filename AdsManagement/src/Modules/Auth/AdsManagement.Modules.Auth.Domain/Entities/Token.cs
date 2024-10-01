using AdsManagement.BuildingBlocks.Domain.Domain.Entities;

namespace AdsManagement.Modules.Auth.Domain.Entities;

public class RefreshToken : Entity
{
    public Guid TokenId { get; set; }
    public string Secret { get; set; }
    public bool IsUsed { get; set; }
    public DateTime ExpiryDate { get; set; }
    
    public Guid OfficerId { get; set; }
    public Officer Officer { get; set; }
}