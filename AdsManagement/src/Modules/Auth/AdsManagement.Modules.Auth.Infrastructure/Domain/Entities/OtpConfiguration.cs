using AdsManagement.Modules.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdsManagement.Modules.Auth.Infrastructure.Domain.Entities;

public class OtpConfiguration : IEntityTypeConfiguration<Otp>
{
    public void Configure(EntityTypeBuilder<Otp> builder)
    {
        builder.ToTable("Otp");
        builder.HasKey(o => o.OtpId);
        
        builder.Property<Guid>("OtpId").HasColumnName("OtpId");
        builder.Property<int>("OtpType").HasColumnName("OtpType");
        builder.Property<string>("Code").HasColumnName("Code");
        builder.Property<bool>("IsUsed").HasColumnName("IsUsed");
        builder.Property<DateTime>("ExpiryDate").HasColumnName("ExpiryDate");
        builder.Property<Guid>("OfficerId").HasColumnName("OfficerId");

        builder
            .HasOne<Officer>(t => t.Officer)
            .WithMany(o => o.Otps)
            .HasForeignKey(t =>t.OfficerId);
    }
}