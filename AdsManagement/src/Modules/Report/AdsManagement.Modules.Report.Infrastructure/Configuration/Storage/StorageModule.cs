using AdsManagement.BuildingBlocks.Application.Files;
using AdsManagement.Modules.Report.Infrastructure.Storage;

using Autofac;
using Azure.Storage.Blobs;

namespace AdsManagement.Modules.Report.Infrastructure.Configuration.Storage;

public class StorageModule : Autofac.Module
{
    private readonly string _connectionString;

    public StorageModule(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder
            .RegisterType(typeof(BlobServiceClient))
            .WithParameter("connectionString", _connectionString)
            .AsSelf()
            .SingleInstance();

        builder
            .RegisterType<StorageService>()
            .As<IStorageService>()
            .InstancePerLifetimeScope();
    }
}