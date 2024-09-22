using AdsManagement.Modules.Advertisement.Application.Contracts;

using System.Reflection;

namespace AdsManagement.Modules.Advertisement.Infrastructure.Configuration;

internal static class Assemblies
{
    public static readonly Assembly Application = typeof(IAdvertisementModule).Assembly;
}