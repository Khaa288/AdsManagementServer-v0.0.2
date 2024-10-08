using AdsManagement.Modules.Report.Infrastructure.Configuration.DataAccess;
using AdsManagement.Modules.Report.Infrastructure.Configuration.EventBus;
using AdsManagement.Modules.Report.Infrastructure.Configuration.Logging;
using AdsManagement.Modules.Report.Infrastructure.Configuration.Mediator;
using AdsManagement.Modules.Report.Infrastructure.Configuration.Processing;
using AdsManagement.Modules.Report.Infrastructure.EventBus;

using Autofac;
using ILogger = Serilog.ILogger;

namespace AdsManagement.Modules.Report.Infrastructure.Configuration;

public class Startup
{
    private static IContainer _container;

    public static void Initialize(
        string connectionString,
        EventBusConfiguration eventBusConfiguration,
        // EmailsConfiguration emailsConfiguration,
        ILogger logger
    )
    {
        var moduleLogger = logger.ForContext("Module", "Auth");

        ConfigureCompositionRoot(
            connectionString,
            eventBusConfiguration,
            // emailsConfiguration, 
            moduleLogger
        );
    }

    private static void ConfigureCompositionRoot(
        string connectionString,
        EventBusConfiguration eventBusConfiguration,
        // EmailsConfiguration emailsConfiguration,
        ILogger logger)
    {
        var containerBuilder = new ContainerBuilder();

        containerBuilder.RegisterModule(new LoggingModule(logger));

        var loggerFactory = new Serilog.Extensions.Logging.SerilogLoggerFactory(logger);

        containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
        containerBuilder.RegisterModule(new EventBusModule(eventBusConfiguration));
        containerBuilder.RegisterModule(new ProcessingModule());
        containerBuilder.RegisterModule(new MediatorModule());
        
        // containerBuilder.RegisterModule(new EmailModule(emailsConfiguration));

        _container = containerBuilder.Build();

        CompositionRoot.SetContainer(_container);
    }
}