using AdsManagement.Modules.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdsManagement.Modules.Auth.Infrastructure.Domain.Entities;

public class WardOfficerConfiguration : IEntityTypeConfiguration<WardOfficer>
{
    public void Configure(EntityTypeBuilder<WardOfficer> builder)
    {
        builder.ToTable("WardOfficer");
        
        builder.Property<int>("WardId").HasColumnName("WardId");
        builder
            .HasOne<Ward>(r => r.Ward)
            .WithOne(p => p.WardOfficer)
            .HasForeignKey<WardOfficer>(o => o.WardId);
    }
}