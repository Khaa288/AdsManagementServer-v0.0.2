using AdsManagement.API.Common;
using AdsManagement.API.Configurations.Extensions;
using AdsManagement.API.Configurations.Validations;
using AdsManagement.BuildingBlocks.Application.Constraints;
using AdsManagement.Modules.Advertisement.Infrastructure.Configuration.Advertisement;
using AdsManagement.Modules.Advertisement.Infrastructure.Database;
using AdsManagement.Modules.Auth.Infrastructure.Configuration.Auth;
using AdsManagement.Modules.Auth.Infrastructure.EventBus;
using AdsManagement.Modules.Auth.Infrastructure.Token;
using AdsManagement.Modules.Report.Infrastructure.Configuration.Report;
using AdsManagement.Modules.Report.Infrastructure.ReCaptcha;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Serilog;
using HeaderConstraints = AdsManagement.BuildingBlocks.Application.Constraints.HeaderConstraints;
using ILogger = Serilog.ILogger;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<ApiExceptionHandler>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Extensions
builder.Services.AddApiSwaggerDocumentation();
builder.Services.AddApiVersions();
builder.Services.AddApiAuthentication(builder.Configuration);
builder.Services.AddApiAuthorization();
builder.Services.AddDevelopmentProblemDetails();

// Registering Module 
builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>((container) =>
    {
        var logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console(
                outputTemplate:
                "[{Timestamp:HH:mm:ss} {Level:u3}] [{Module}] [{Context}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        var tokensConfiguration = new TokensConfiguration(
            builder.Configuration["Jwt:Issuer"],
            builder.Configuration["Jwt:Audience"],
            builder.Configuration["Jwt:Key"]
        );

        var eventBusConfiguration = new EventBusConfiguration(
            builder.Configuration["EventBus:HostName"],   
            builder.Configuration["EventBus:Username"],   
            builder.Configuration["EventBus:Password"]
        );
        
        // Register module here
        container.RegisterModule(new AuthAutoFacModule());
        container.RegisterModule(new AdvertisementAutoFacModule());
        container.RegisterModule(new ReportAutoFacModule());
        
        // Initialize module here
        AdsManagement.Modules.Auth.Infrastructure.Configuration.Startup.Initialize(
            builder.Configuration["Databases:AuthModuleDb:Sql:ConnectionString"],
            tokensConfiguration,
            eventBusConfiguration,
            logger
        );
        
        AdsManagement.Modules.Advertisement.Infrastructure.Configuration.Startup.Initialize(
            new DatabaseConfiguration(
                builder.Configuration["Databases:AdvertisementModuleDb:NoSql:MongoDb:ConnectionString"],
                builder.Configuration["Databases:AdvertisementModuleDb:NoSql:MongoDb:DatabaseName"]
                ),
            new AdsManagement.Modules.Advertisement.Infrastructure.EventBus.EventBusConfiguration(
                builder.Configuration["EventBus:HostName"],   
                builder.Configuration["EventBus:Username"],   
                builder.Configuration["EventBus:Password"]
                ),
            builder.Configuration["Databases:AdvertisementModuleDb:NoSql:Redis:ConnectionString"],
            logger
        );
        
        AdsManagement.Modules.Report.Infrastructure.Configuration.Startup.Initialize(
            builder.Configuration["Databases:ReportModuleDb:Sql:ConnectionString"],
            new AdsManagement.Modules.Report.Infrastructure.EventBus.EventBusConfiguration(
                builder.Configuration["EventBus:HostName"],   
                builder.Configuration["EventBus:Username"],   
                builder.Configuration["EventBus:Password"]
            ),
            builder.Configuration["Storages:ReportModule:ConnectionString"],
            new ReCaptchaConfiguration(
                builder.Configuration["ReCaptcha:ReportModule:ReCaptchaSecret"],
                builder.Configuration["ReCaptcha:ReportModule:ReCaptchaVerifySite"]
            ),
            logger
        );
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDevelopmentProblemDetails();
    //app.UseExceptionHandler(options => {});
    
    app.UseSwaggerDocumentation();
    
    app.UseCors(options => options
        .SetIsOriginAllowed(origin => true)
        .AllowCredentials()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders(HeaderConstraints.XPagination));
}
else
{
    app.UseExceptionHandler(options => {});
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();