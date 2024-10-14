using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;

namespace AdsManagement.Modules.Report.Infrastructure.Configuration.Mapping;

public class MappingModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAutoMapper(Assemblies.Application);
    }
}