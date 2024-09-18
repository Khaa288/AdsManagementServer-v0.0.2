using AdsManagement.BuildingBlocks.Application.Constraints;
using AdsManagement.BuildingBlocks.Application.Constraints.Constants;
using Microsoft.AspNetCore.Authorization;

namespace AdsManagement.API.Configurations.Extensions;

internal static class AuthorizationExtension
{
    internal static IServiceCollection AddApiAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.DefaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim(HeaderConstraints.TokenType, TokenTypeNames.Access)
                .Build();
        });

        return services;
    }
}