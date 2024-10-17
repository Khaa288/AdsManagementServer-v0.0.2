using AdsManagement.Modules.Report.Application.ReCaptcha;
using AdsManagement.Modules.Report.Infrastructure.ReCaptcha;

using Autofac;

namespace AdsManagement.Modules.Report.Infrastructure.Configuration.ReCaptcha;

public class ReCaptchaModule : Autofac.Module
{
    private readonly ReCaptchaConfiguration _configuration;

    public ReCaptchaModule(ReCaptchaConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<HttpClient>()
            .AsSelf()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<ReCaptchaService>()
            .As<IReCaptchaService>()
            .WithParameter("configuration", _configuration)
            .InstancePerLifetimeScope();
    }
}