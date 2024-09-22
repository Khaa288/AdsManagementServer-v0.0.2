using AdsManagement.Modules.Advertisement.Infrastructure.Database;

using Autofac;
using Microsoft.Extensions.Logging;

namespace AdsManagement.Modules.Advertisement.Infrastructure.Configuration.DataAccess;

internal class DataAccessModule : Autofac.Module
{
    private readonly DatabaseConfiguration _configuration;
    private readonly ILoggerFactory _loggerFactory;
    
    internal DataAccessModule(DatabaseConfiguration configuration, ILoggerFactory loggerFactory)
    {
        _configuration = configuration;
        _loggerFactory = loggerFactory;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AdvertisementContext>()
            .WithParameter("configuration", _configuration)
            .AsSelf()
            .InstancePerLifetimeScope();

        var infrastructureAssembly = typeof(AdvertisementContext).Assembly;

        builder.RegisterAssemblyTypes(infrastructureAssembly)
            .Where(type => type.Name.EndsWith("Repository"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope()
            .FindConstructorsWith(new AllConstructorFinder());
    }
}