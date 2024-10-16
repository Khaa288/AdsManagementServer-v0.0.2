using AdsManagement.BuildingBlocks.Domain;
using AdsManagement.BuildingBlocks.Infrastructure;

using Autofac;

namespace AdsManagement.Modules.Auth.Infrastructure.Configuration.Processing;

internal class ProcessingModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();
        }
    }