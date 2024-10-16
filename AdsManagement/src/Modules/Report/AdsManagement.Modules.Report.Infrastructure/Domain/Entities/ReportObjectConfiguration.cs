using AdsManagement.Modules.Report.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdsManagement.Modules.Report.Infrastructure.Domain.Entities;

public class ReportObjectConfiguration : IEntityTypeConfiguration<ReportObject>
{
    public void Configure(EntityTypeBuilder<ReportObject> builder)
    {
        builder.ToTable("ReportObject");
        builder.HasKey(ro => ro.SurrogateKey);
        builder.HasIndex(ro => new { ro.ObjectId, ro.ObjectType }).IsUnique(true);
        
        builder.Property<Guid>("ObjectId").HasColumnName("ObjectId");
        builder.Property<string>("ObjectType").HasColumnName("ObjectType");
        builder.Property<string>("Address").HasColumnName("Address");
        builder.Property<string>("DistrictName").HasColumnName("DistrictName");
        builder.Property<string>("WardName").HasColumnName("WardName");
    }
}