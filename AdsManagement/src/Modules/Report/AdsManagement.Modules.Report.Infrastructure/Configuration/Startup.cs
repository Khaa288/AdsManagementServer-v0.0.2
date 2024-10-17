using AdsManagement.Modules.Report.Infrastructure.Configuration.DataAccess;
using AdsManagement.Modules.Report.Infrastructure.Configuration.EventBus;
using AdsManagement.Modules.Report.Infrastructure.Configuration.Logging;
using AdsManagement.Modules.Report.Infrastructure.Configuration.Mapping;
using AdsManagement.Modules.Report.Infrastructure.Configuration.Mediator;
using AdsManagement.Modules.Report.Infrastructure.Configuration.Processing;
using AdsManagement.Modules.Report.Infrastructure.Configuration.ReCaptcha;
using AdsManagement.Modules.Report.Infrastructure.Configuration.Storage;
using AdsManagement.Modules.Report.Infrastructure.EventBus;
using AdsManagement.Modules.Report.Infrastructure.ReCaptcha;
using Autofac;
using ILogger = Serilog.ILogger;

namespace AdsManagement.Modules.Report.Infrastructure.Configuration;

public class Startup
{
    private static IContainer _container;

    public static void Initialize(
        string connectionString,
        EventBusConfiguration eventBusConfiguration,
        string storageConnectionString,
        ReCaptchaConfiguration reCaptchaConfiguration,
        // EmailsConfiguration emailsConfiguration,
        ILogger logger
    )
    {
        var moduleLogger = logger.ForContext("Module", "Report");

        ConfigureCompositionRoot(
            connectionString,
            eventBusConfiguration,
            storageConnectionString,
            reCaptchaConfiguration,
            // emailsConfiguration, 
            moduleLogger
        );
    }

    private static void ConfigureCompositionRoot(
        string connectionString,
        EventBusConfiguration eventBusConfiguration,
        string storageConnectionString,
        ReCaptchaConfiguration reCaptchaConfiguration,
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
        containerBuilder.RegisterModule(new MappingModule());
        containerBuilder.RegisterModule(new StorageModule(storageConnectionString));
        containerBuilder.RegisterModule(new ReCaptchaModule(reCaptchaConfiguration));
        
        // containerBuilder.RegisterModule(new EmailModule(emailsConfiguration));

        _container = containerBuilder.Build();

        CompositionRoot.SetContainer(_container);
    }
}