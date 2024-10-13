using AdsManagement.BuildingBlocks.Application.Common.Files;
using AdsManagement.BuildingBlocks.Application.Files;

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace AdsManagement.Modules.Report.Infrastructure.Storage;

public class StorageService : IStorageService
{
    private readonly BlobServiceClient _blobClient;
    private const string ReportBlobContainer = "ads-management-report-container";

    public StorageService(BlobServiceClient blobClient)
    {
        _blobClient = blobClient;
        _blobClient.GetBlobContainerClient(ReportBlobContainer).CreateIfNotExistsAsync();
    }
  
    public async Task<List<string>> UploadAsync(ICollection<FileData> files)
    {
        if (files == null || files.Count == 0)
        {
            return null;
        }
        
        var blobContainer = _blobClient.GetBlobContainerClient(ReportBlobContainer);
        var urls = new List<string>();

        foreach (var file in files)
        {
            var blobClient = blobContainer.GetBlobClient(file.GetPathWithFileName("report"));

            await blobClient.UploadAsync(file.Content, new BlobHttpHeaders() { ContentType = file.ContentType });
            
            urls.Add(blobClient.Uri.ToString());
        }

        return urls;
    }
}