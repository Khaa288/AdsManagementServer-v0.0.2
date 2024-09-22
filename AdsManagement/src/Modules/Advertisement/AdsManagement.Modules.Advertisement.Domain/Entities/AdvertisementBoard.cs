namespace AdsManagement.Modules.Advertisement.Domain.Entities;

public class AdvertisementBoard
{
    public Guid BoardId { get; set; }
    public string BoardType { get; set; }
    public Guid PointId { get; set; }
    public string Size { get; set; }
    public DateTime ExpiryDate { get; set; }
    public List<string> Images { get; set; } = new List<string>();
}