using AdsManagement.API.Configurations.Validations;
using AdsManagement.BuildingBlocks.Application;

namespace AdsManagement.API.Configurations.Extensions;
using Hellang.Middleware.ProblemDetails;

internal static class DevProblemDetailsExtension
{
    internal static IServiceCollection AddDevelopmentProblemDetails(this IServiceCollection services)
    {
        services.AddProblemDetails(x =>
        {
            x.Map<InvalidCommandException>(ex => new InvalidCommandProblemDetails(ex));
        });

        return services;
    }

    internal static WebApplication UseDevelopmentProblemDetails(this WebApplication app)
    {
        app.UseProblemDetails();

        return app;
    }
}