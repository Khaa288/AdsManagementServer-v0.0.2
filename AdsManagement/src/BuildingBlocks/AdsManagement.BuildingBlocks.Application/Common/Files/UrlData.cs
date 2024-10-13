namespace AdsManagement.BuildingBlocks.Application.Common.Files;

public class UrlData
{
    public ICollection<string> Urls { get; }

    public UrlData(ICollection<string> urls)
    {
        Urls = urls;
    }
}