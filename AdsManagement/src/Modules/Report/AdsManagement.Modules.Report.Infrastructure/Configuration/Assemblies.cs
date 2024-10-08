using AdsManagement.Modules.Report.Application.Contracts;

using System.Reflection;

namespace AdsManagement.Modules.Report.Infrastructure.Configuration;

internal static class Assemblies
{
    public static readonly Assembly Application = typeof(IReportModule).Assembly;
}