using AdsManagement.Modules.Auth.Application.Tokens;
using AdsManagement.Modules.Auth.Infrastructure.Token;
using Autofac;
using Microsoft.Extensions.Configuration;

namespace AdsManagement.Modules.Auth.Infrastructure.Configuration.Token;

public class TokenModule : Module
{
    private readonly TokensConfiguration _configuration;
    
    public TokenModule(TokensConfiguration configuration)
    {
        this._configuration = configuration;
    }
    
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<TokenService>()
            .As<ITokenService>()
            .WithParameter("configuration", _configuration)
            .InstancePerLifetimeScope();
    }
}