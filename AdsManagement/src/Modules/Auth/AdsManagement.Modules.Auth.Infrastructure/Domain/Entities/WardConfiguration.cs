using AdsManagement.Modules.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdsManagement.Modules.Auth.Infrastructure.Domain.Entities;

public class WardConfiguration : IEntityTypeConfiguration<Ward>
{
    public void Configure(EntityTypeBuilder<Ward> builder)
    {
        builder.ToTable("Ward");
        builder.HasKey(o => o.WardId);
        
        builder.Property<int>("WardId").HasColumnName("WardId").ValueGeneratedNever();
        builder.Property<string>("WardName").HasColumnName("WardName");
        builder.Property<int>("DistrictId").HasColumnName("DistrictId");

        builder
            .HasOne<District>(t => t.District)
            .WithMany(o => o.Wards)
            .HasForeignKey(t =>t.DistrictId);
    }
}