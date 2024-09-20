using AdsManagement.Modules.Auth.Application.Contracts;

using System.Reflection;

namespace AdsManagement.Modules.Auth.Infrastructure.Configuration;

internal static class Assemblies
{
    public static readonly Assembly Application = typeof(IAuthModule).Assembly;
}