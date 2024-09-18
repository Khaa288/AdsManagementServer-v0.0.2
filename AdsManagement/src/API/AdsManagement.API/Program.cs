using AdsManagement.API.Configurations.Extensions;
using AdsManagement.API.Configurations.Validations;
using AdsManagement.BuildingBlocks.Application.Constraints;
using AdsManagement.Modules.Auth.Infrastructure.Configuration.Auth;
using AdsManagement.Modules.Auth.Infrastructure.Token;

using Autofac;
using Autofac.Extensions.DependencyInjection;
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
builder.Services.AddExceptionHandler<ApiExceptionHandler>();

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
        
        // Register module here
        container.RegisterModule(new AuthAutoFacModule());
        
        // Initialize module here
        AdsManagement.Modules.Auth.Infrastructure.Configuration.Startup.Initialize(
            builder.Configuration.GetConnectionString(builder.Configuration["Databases:AuthModuleDb:Sql:ConnectionString"]),
            logger,
            tokensConfiguration
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