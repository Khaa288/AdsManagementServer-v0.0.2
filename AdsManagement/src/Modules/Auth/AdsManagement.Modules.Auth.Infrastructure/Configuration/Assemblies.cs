using System.Reflection;
using AdsManagement.Modules.Auth.Application.Contracts;

namespace AdsManagement.Modules.Auth.Infrastructure.Configuration;

internal static class Assemblies
{
    public static readonly Assembly Application = typeof(IAuthModule).Assembly;
}