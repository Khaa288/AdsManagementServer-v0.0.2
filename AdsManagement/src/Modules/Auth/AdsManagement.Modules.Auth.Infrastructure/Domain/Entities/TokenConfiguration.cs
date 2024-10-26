using AdsManagement.Modules.Auth.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdsManagement.Modules.Auth.Infrastructure.Domain.Entities;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshToken");
        builder.HasKey(o => o.TokenId);
        
        builder.Property<Guid>("TokenId").HasColumnName("TokenId");
        builder.Property<string>("Secret").HasColumnName("Secret");
        builder.Property<bool>("IsUsed").HasColumnName("IsUsed");
        builder.Property<DateTime>("ExpiryDate").HasColumnName("ExpiryDate");
        builder.Property<Guid>("OfficerId").HasColumnName("OfficerId");

        builder
            .HasOne<Officer>(t => t.Officer)
            .WithOne()
            .HasForeignKey<RefreshToken>(t =>t.OfficerId);
    }
}