using AdsManagement.Modules.Advertisement.Infrastructure.Configuration.Caching;
using AdsManagement.Modules.Advertisement.Infrastructure.Configuration.DataAccess;
using AdsManagement.Modules.Advertisement.Infrastructure.Configuration.EventBus;
using AdsManagement.Modules.Advertisement.Infrastructure.Configuration.Logging;
using AdsManagement.Modules.Advertisement.Infrastructure.Configuration.Mediator;
using AdsManagement.Modules.Advertisement.Infrastructure.Configuration.Processing;
using AdsManagement.Modules.Advertisement.Infrastructure.Database;
using AdsManagement.Modules.Advertisement.Infrastructure.EventBus;

using Autofac;
using ILogger = Serilog.ILogger;

namespace AdsManagement.Modules.Advertisement.Infrastructure.Configuration;

public class Startup
{
    private static IContainer _container;

    public static void Initialize(
        DatabaseConfiguration configuration,
        EventBusConfiguration eventBusConfiguration,
        string cacheConnectionString,
        ILogger logger
    )
    {
        var moduleLogger = logger.ForContext("Module", "Advertisement");

        ConfigureCompositionRoot(
            configuration,
            eventBusConfiguration,
            cacheConnectionString,
            moduleLogger
        );
    }

    private static void ConfigureCompositionRoot(
        DatabaseConfiguration configuration,
        EventBusConfiguration eventBusConfiguration,
        string cacheConnectionString,
        ILogger logger)
    {
        var containerBuilder = new ContainerBuilder();

        var loggerFactory = new Serilog.Extensions.Logging.SerilogLoggerFactory(logger);
        
        containerBuilder.RegisterModule(new LoggingModule(logger));
        containerBuilder.RegisterModule(new DataAccessModule(configuration, loggerFactory));
        containerBuilder.RegisterModule(new EventBusModule(eventBusConfiguration));
        containerBuilder.RegisterModule(new ProcessingModule());
        containerBuilder.RegisterModule(new MediatorModule());
        containerBuilder.RegisterModule(new CachingModule(cacheConnectionString));

        _container = containerBuilder.Build();

        CompositionRoot.SetContainer(_container);
    }
}