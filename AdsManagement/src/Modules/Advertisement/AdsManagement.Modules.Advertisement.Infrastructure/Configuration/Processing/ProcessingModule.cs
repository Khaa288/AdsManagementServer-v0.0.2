using AdsManagement.BuildingBlocks.Infrastructure;

using Autofac;

namespace AdsManagement.Modules.Advertisement.Infrastructure.Configuration.Processing;

internal class ProcessingModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UnitOfWork>()
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();
    }
}