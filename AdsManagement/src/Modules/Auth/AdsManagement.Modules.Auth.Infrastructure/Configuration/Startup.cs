using AdsManagement.Modules.Auth.Infrastructure.Configuration.DataAccess;
using AdsManagement.Modules.Auth.Infrastructure.Configuration.EventBus;
using AdsManagement.Modules.Auth.Infrastructure.Configuration.Logging;
using AdsManagement.Modules.Auth.Infrastructure.Configuration.Mediator;
using AdsManagement.Modules.Auth.Infrastructure.Configuration.Processing;
using AdsManagement.Modules.Auth.Infrastructure.Configuration.Token;
using AdsManagement.Modules.Auth.Infrastructure.EventBus;
using AdsManagement.Modules.Auth.Infrastructure.Token;
using Autofac;
using ILogger = Serilog.ILogger;

namespace AdsManagement.Modules.Auth.Infrastructure.Configuration;

public class Startup
{
    private static IContainer _container;

    public static void Initialize(
        string connectionString,
        TokensConfiguration tokensConfiguration,
        EventBusConfiguration eventBusConfiguration,
        // EmailsConfiguration emailsConfiguration,
        ILogger logger
    )
    {
        var moduleLogger = logger.ForContext("Module", "Auth");

        ConfigureCompositionRoot(
            connectionString,
            tokensConfiguration,
            eventBusConfiguration,
            // emailsConfiguration, 
            moduleLogger
        );
    }

    private static void ConfigureCompositionRoot(
        string connectionString,
        TokensConfiguration tokensConfiguration,
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
        containerBuilder.RegisterModule(new TokenModule(tokensConfiguration));
        
        // containerBuilder.RegisterModule(new EmailModule(emailsConfiguration));

        _container = containerBuilder.Build();

        CompositionRoot.SetContainer(_container);
    }
}