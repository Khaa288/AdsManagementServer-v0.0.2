﻿using AdsManagement.BuildingBlocks.Domain.Domain.Entities;

namespace AdsManagement.Modules.Auth.Domain.Entities;

public class Otp : Entity
{
    public Guid OtpId { get; set; }
    public int OtpType { get; set; }
    public string Code { get; set; }
    public bool IsUsed { get; set; }
    public DateTime ExpiryDate { get; set; }
    
    public Guid OfficerId { get; set; }
    public Officer Officer { get; set; }
}