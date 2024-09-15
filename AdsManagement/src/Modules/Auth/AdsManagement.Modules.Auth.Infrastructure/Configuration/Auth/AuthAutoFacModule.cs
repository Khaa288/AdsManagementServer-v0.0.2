using AdsManagement.Modules.Auth.Application.Contracts;
using Autofac;

namespace AdsManagement.Modules.Auth.Infrastructure.Configuration.Auth;

public class AuthAutoFacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AuthModule>()
            .As<IAuthModule>()
            .InstancePerLifetimeScope();
    }
}