using AdsManagement.Modules.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdsManagement.Modules.Auth.Infrastructure.Domain.Entities;

public class PrivilegeConfiguration : IEntityTypeConfiguration<Privilege>
{
    public void Configure(EntityTypeBuilder<Privilege> builder)
    {
        builder.ToTable("Privilege");
        builder.HasKey(o => o.PrivilegeId);
        
        builder.Property<Guid>("PrivilegeId").HasColumnName("PrivilegeId");
        builder.Property<string>("PrivilegeName").HasColumnName("PrivilegeName");
    }
}