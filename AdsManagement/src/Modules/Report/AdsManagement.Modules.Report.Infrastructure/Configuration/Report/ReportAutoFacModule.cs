using AdsManagement.Modules.Report.Application.Contracts;

using Autofac;

namespace AdsManagement.Modules.Report.Infrastructure.Configuration.Report;

public class ReportAutoFacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ReportModule>()
            .As<IReportModule>()
            .InstancePerLifetimeScope();
    }
}