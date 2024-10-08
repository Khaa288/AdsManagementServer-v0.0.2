using AdsManagement.Modules.Report.Domain.Entities;
using AdsManagement.Modules.Report.Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace AdsManagement.Modules.Report.Infrastructure.Database;

public class ReportContext : DbContext
{
    public DbSet<Report.Domain.Entities.Report> Reports { get; set; }
    public DbSet<Reporter> Reporters { get; set; }
    public DbSet<ReportImage> ReportImages { get; set; }
    public DbSet<ReportObject> ReportObjects { get; set; }
    
    private readonly ILoggerFactory _loggerFactory;
    
    public ReportContext(DbContextOptions options, ILoggerFactory loggerFactory)
        : base(options)
    {
        _loggerFactory = loggerFactory;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ReportConfiguration());
        modelBuilder.ApplyConfiguration(new ReporterConfiguration());
        modelBuilder.ApplyConfiguration(new ReportImageConfiguration());
        modelBuilder.ApplyConfiguration(new ReportObjectConfiguration());
    }
}

// Note: Temporary Class for EF Core actions like Migration, will delete soon in production
public class ReportContextFactory : IDesignTimeDbContextFactory<ReportContext>
{
    public ReportContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ReportContext>();
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ReportModuleDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;");

        return new ReportContext(optionsBuilder.Options, null);
    }
}