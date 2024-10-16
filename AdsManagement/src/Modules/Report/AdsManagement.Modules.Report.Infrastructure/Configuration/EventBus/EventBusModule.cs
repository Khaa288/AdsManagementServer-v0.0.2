using AdsManagement.BuildingBlocks.Application.EventBus;
using AdsManagement.Modules.Report.Infrastructure.EventBus;

using Autofac;
using Autofac.Extensions.DependencyInjection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace AdsManagement.Modules.Report.Infrastructure.Configuration.EventBus;

public class EventBusModule : Autofac.Module
{
    private readonly EventBusConfiguration _configuration;

     public EventBusModule(EventBusConfiguration configuration)
     {
         _configuration = configuration;
     }

    protected override void Load(ContainerBuilder builder)
    {
        var services = new ServiceCollection();
        services.AddMassTransit(x =>
        {
            x.AddConsumers();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(_configuration.HostName, h =>
                {
                    h.Username(_configuration.UserName);
                    h.Password(_configuration.Password);
                });
                cfg.ConfigureEndpoints(context);
            });
        });
        builder.Populate(services);
        
        builder.RegisterType<EventBusService>()
            .As<IEventBus>()
            .WithParameter("configuration", _configuration)
            .InstancePerLifetimeScope();
    }
}