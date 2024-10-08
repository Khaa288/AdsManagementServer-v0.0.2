using AdsManagement.Modules.Report.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdsManagement.Modules.Report.Infrastructure.Domain.Entities;

public class ReporterConfiguration : IEntityTypeConfiguration<Reporter>
{
    public void Configure(EntityTypeBuilder<Reporter> builder)
    {
        builder.ToTable("Reporter");
        builder.HasKey(r => r.ReporterId);
        
        builder.Property<Guid>("ReporterId").HasColumnName("ReporterId");
        builder.Property<string>("Name").HasColumnName("Name");
        builder.Property<string>("Email").HasColumnName("Email");
        builder.Property<string>("PhoneNumber").HasColumnName("PhoneNumber");
    }
}