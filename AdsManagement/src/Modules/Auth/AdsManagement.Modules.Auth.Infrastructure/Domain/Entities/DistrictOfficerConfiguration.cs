using AdsManagement.Modules.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdsManagement.Modules.Auth.Infrastructure.Domain.Entities;

public class DistrictOfficerConfiguration : IEntityTypeConfiguration<DistrictOfficer>
{
    public void Configure(EntityTypeBuilder<DistrictOfficer> builder)
    {
        builder.ToTable("DistrictOfficer");
        
        builder.Property<int>("DistrictId").HasColumnName("DistrictId");
        builder
            .HasOne<District>(r => r.District)
            .WithOne(p => p.DistrictOfficer)
            .HasForeignKey<DistrictOfficer>(o => o.DistrictId);
    }
}