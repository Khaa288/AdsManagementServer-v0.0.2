using AdsManagement.Modules.Report.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdsManagement.Modules.Report.Infrastructure.Domain.Entities;

public class ReportConfiguration : IEntityTypeConfiguration<Report.Domain.Entities.Report>
{
    public void Configure(EntityTypeBuilder<Report.Domain.Entities.Report> builder)
    {
        builder.ToTable("Report");
        builder.HasKey(r => r.ReportId);
        
        builder.Property<Guid>("ReportId").HasColumnName("ReportId");
        builder.Property<string>("ReportType").HasColumnName("ReportType");
        builder.Property<string>("Content").HasColumnName("Content");
        builder.Property<string>("Solution").HasColumnName("Solution");
        builder.Property<int>("Status").HasColumnName("Status");
        builder.Property<DateTime>("CreatedTime").HasColumnName("CreatedTime");
        builder.Property<int>("ReportObjectId").HasColumnName("ReportObjectId");
        builder.Property<Guid>("ReporterId").HasColumnName("ReporterId");

        builder
            .HasOne(r => r.Reporter)
            .WithMany(r => r.Reports)
            .HasForeignKey(r => r.ReporterId);

        builder
            .HasOne(r => r.ReportObject)
            .WithMany(ro => ro.Reports)
            .HasForeignKey(r => r.ReportObjectId);
    }
}