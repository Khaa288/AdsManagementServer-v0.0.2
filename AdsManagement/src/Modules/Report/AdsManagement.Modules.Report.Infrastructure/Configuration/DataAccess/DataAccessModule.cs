using AdsManagement.BuildingBlocks.Application.Data;
using AdsManagement.BuildingBlocks.Infrastructure;
using AdsManagement.Modules.Report.Infrastructure.Database;

using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AdsManagement.Modules.Report.Infrastructure.Configuration.DataAccess;

internal class DataAccessModule : Autofac.Module
{
    private readonly string _databaseConnectionString;
    private readonly ILoggerFactory _loggerFactory;
    
    internal DataAccessModule(string databaseConnectionString, ILoggerFactory loggerFactory)
    {
        _databaseConnectionString = databaseConnectionString;
        _loggerFactory = loggerFactory;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<SqlConnectionFactory>()
            .As<ISqlConnectionFactory>()
            .WithParameter("connectionString", _databaseConnectionString)
            .InstancePerLifetimeScope();

        builder.Register(c =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<ReportContext>();
                dbContextOptionsBuilder.UseSqlServer(_databaseConnectionString);

                return new ReportContext(dbContextOptionsBuilder.Options, _loggerFactory);
            })
            .AsSelf()
            .As<DbContext>()
            .InstancePerLifetimeScope();

        var infrastructureAssembly = typeof(ReportContext).Assembly;

        builder.RegisterAssemblyTypes(infrastructureAssembly)
            .Where(type => type.Name.EndsWith("Repository"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope()
            .FindConstructorsWith(new AllConstructorFinder());
    }
}