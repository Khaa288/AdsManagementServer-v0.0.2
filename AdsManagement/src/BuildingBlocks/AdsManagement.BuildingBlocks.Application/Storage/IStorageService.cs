using AdsManagement.BuildingBlocks.Application.Common.Files;

namespace AdsManagement.BuildingBlocks.Application.Files;

public interface IStorageService
{
    Task<List<string>> UploadAsync(ICollection<FileData> files);
}