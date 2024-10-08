using AdsManagement.BuildingBlocks.Infrastructure;
using AdsManagement.Modules.Report.Application.Configuration.Commands;

using Autofac;

namespace AdsManagement.Modules.Report.Infrastructure.Configuration.Processing;

internal class ProcessingModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();
        }
    }