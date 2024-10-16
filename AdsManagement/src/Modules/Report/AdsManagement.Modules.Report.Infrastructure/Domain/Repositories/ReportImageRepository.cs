using AdsManagement.Modules.Report.Domain.Entities;
using AdsManagement.Modules.Report.Domain.Repositories;
using AdsManagement.Modules.Report.Infrastructure.Database;

namespace AdsManagement.Modules.Report.Infrastructure.Domain.Repositories;

internal class ReportImageRepository : IReportImageRepository
{
    private readonly ReportContext _reportContext;
    
    public ReportImageRepository(ReportContext reportContext)
    {
        _reportContext = reportContext;
    }

    public async Task AddReportImagesAsync(Guid reportId, List<string> urls)
    {
        var images = new List<ReportImage>();

        urls.ForEach(url => 
        {
            images.Add(new ReportImage()
            {
                ImageId = Guid.NewGuid(),
                ReportId = reportId,
                Url = url,
            });
        });

        await _reportContext.ReportImages.AddRangeAsync(images);
    }
}