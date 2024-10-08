using AdsManagement.Modules.Report.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdsManagement.Modules.Report.Infrastructure.Domain.Entities;

public class ReportImageConfiguration : IEntityTypeConfiguration<ReportImage>
{
    public void Configure(EntityTypeBuilder<ReportImage> builder)
    {
        builder.ToTable("ReportImage");
        builder.HasKey(o => o.ImageId);
        
        builder.Property<Guid>("ImageId").HasColumnName("ImageId");
        builder.Property<Guid>("ReportId").HasColumnName("ReportId");
        builder.Property<string>("Url").HasColumnName("Url");

        builder
            .HasOne(ri => ri.Report)
            .WithMany(r => r.ReportImages)
            .HasForeignKey(ri => ri.ReportId);
    }
}