using AdsManagement.Modules.Auth.Application.Cryptos;
using AdsManagement.Modules.Auth.Infrastructure.Password;
using Autofac;

namespace AdsManagement.Modules.Auth.Infrastructure.Configuration.Crypto;

public class CryptoModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CryptoService>()
            .As<ICryptoService>()
            .InstancePerLifetimeScope();
    }
}