﻿using AdsManagement.BuildingBlocks.Domain.Domain.Entities;

namespace AdsManagement.Modules.Auth.Domain.Entities;

public class District : Entity
{
    public int DistrictId { get; set; }
    public string DistrictName { get; set; }
    
    public List<Ward> Wards { get; set; }
    public DistrictOfficer DistrictOfficer { get; set; }
}