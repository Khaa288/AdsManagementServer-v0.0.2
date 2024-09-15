using AdsManagement.API.Common;
using AdsManagement.API.Configurations.Extensions;
using AdsManagement.BuildingBlocks.Application;
using AdsManagement.Modules.Auth.Infrastructure;
using AdsManagement.Modules.Auth.Infrastructure.Configuration;
using AdsManagement.Modules.Auth.Infrastructure.Configuration.Auth;
using Asp.Versioning;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
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

// Extensions
builder.Services.AddSwaggerDocumentation();
builder.Services.AddApiVersions();

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
        
        // Register module here
        container.RegisterModule(new AuthAutoFacModule());
        
        // Initialize module here
        AdsManagement.Modules.Auth.Infrastructure.Configuration.Startup.Initialize(
            builder.Configuration.GetConnectionString("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AuthModuleDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;"),
            logger
        );
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
    
    app.UseCors(options => options
        .SetIsOriginAllowed(origin => true)
        .AllowCredentials()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders(HeaderConstraints.XPagination));
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();