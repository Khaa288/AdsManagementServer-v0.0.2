using AdsManagement.Modules.Advertisement.Application.Contracts;

using Autofac;

namespace AdsManagement.Modules.Advertisement.Infrastructure.Configuration.Advertisement;

public class AdvertisementAutoFacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AdvertisementModule>()
            .As<IAdvertisementModule>()
            .InstancePerLifetimeScope();
    }   
}