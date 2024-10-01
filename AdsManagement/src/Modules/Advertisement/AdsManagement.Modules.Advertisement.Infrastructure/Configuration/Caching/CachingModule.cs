using AdsManagement.Modules.Advertisement.Application.Caching;
using AdsManagement.Modules.Advertisement.Infrastructure.Caching;

using Autofac;

namespace AdsManagement.Modules.Advertisement.Infrastructure.Configuration.Caching;

internal class CachingModule : Autofac.Module
{
    private readonly string _connectionString;

    public CachingModule(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder
            .RegisterType<CachingDatabase>()
            .As<ICachingDatabase>()
            .WithParameter("connectionString", _connectionString)
            .SingleInstance();

        builder
            .RegisterType<CachingService>()
            .As<ICachingService>()
            .InstancePerLifetimeScope();
    }
}