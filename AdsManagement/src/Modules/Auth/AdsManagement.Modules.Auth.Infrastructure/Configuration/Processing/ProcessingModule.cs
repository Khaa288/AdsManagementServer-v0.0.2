using AdsManagement.BuildingBlocks.Infrastructure;
using AdsManagement.Modules.Auth.Application.Configuration.Commands;

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