using AdsManagement.Modules.Auth.Domain.Entities;
using AdsManagement.Modules.Auth.Infrastructure.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace AdsManagement.Modules.Auth.Infrastructure.Database;

public class AuthContext : DbContext
{
    public DbSet<Officer> Officers { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Privilege> Privileges { get; set; }
    public DbSet<Ward> Wards { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Otp> Otps { get; set; }
    public DbSet<RefreshToken> Tokens { get; set; }
    
    private readonly ILoggerFactory _loggerFactory;
    
    public AuthContext(DbContextOptions options, ILoggerFactory loggerFactory)
        : base(options)
    {
        _loggerFactory = loggerFactory;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OfficerConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new PrivilegeConfiguration());
        modelBuilder.ApplyConfiguration(new OtpConfiguration());
        modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
        modelBuilder.ApplyConfiguration(new WardConfiguration());
        modelBuilder.ApplyConfiguration(new DistrictConfiguration());
    }
}

// Note: Temporary Class for EF Core actions like Migration, will delete soon in production
public class AuthContextFactory : IDesignTimeDbContextFactory<AuthContext>
{
    public AuthContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AuthContext>();
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AuthModuleDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;");

        return new AuthContext(optionsBuilder.Options, null);
    }
}