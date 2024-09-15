﻿using AdsManagement.Modules.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdsManagement.Modules.Auth.Infrastructure.Domain.Entities;

public class OfficerConfiguration : IEntityTypeConfiguration<Officer>
{
    public void Configure(EntityTypeBuilder<Officer> builder)
    {
        builder.ToTable("Officers");
        builder.HasKey(o => o.OfficerId);
        
        builder.Property<Guid>("OfficerId").HasColumnName("OfficerId");
        builder.Property<string>("FullName").HasColumnName("FullName");
        builder.Property<DateTime>("DoB").HasColumnName("DoB");
        builder.Property<string>("Email").HasColumnName("Email");
        builder.Property<string>("PhoneNumber").HasColumnName("PhoneNumber");
        builder.Property<string>("PasswordHash").HasColumnName("PasswordHash");
        builder.Property<int>("WardId").HasColumnName("WardId");
    }
}