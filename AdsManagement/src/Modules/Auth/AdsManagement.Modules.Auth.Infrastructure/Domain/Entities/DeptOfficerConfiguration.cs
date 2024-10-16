using AdsManagement.Modules.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdsManagement.Modules.Auth.Infrastructure.Domain.Entities;

public class DeptOfficerConfiguration : IEntityTypeConfiguration<DeptOfficer>
{
    public void Configure(EntityTypeBuilder<DeptOfficer> builder)
    {
        builder.ToTable("DeptOfficer");
        builder.HasKey(o => o.OfficerId);
    }
}