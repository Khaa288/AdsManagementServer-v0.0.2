using AdsManagement.Modules.Advertisement.Domain.Entities;

using System.Linq.Expressions;

namespace AdsManagement.Modules.Advertisement.Domain.Repositories;

public interface IAdvertisementPointRepository
{
    Task<List<AdvertisementPoint>> GetAllAdvertisementPoints();
    Task<(List<AdvertisementPoint>, int)> GetPaginAdvertisementPoints(int page, int pageSize, Expression<Func<AdvertisementPoint,bool>>? filter);
    Task<AdvertisementPoint> GetAdvertisementPointByPointId(Guid pointId);
    Task<List<AdvertisementPoint>> GetAdvertisementPointsByWardId(int wardId);
    Task<List<AdvertisementPoint>> GetAdvertisementPointsByDistrictId(int districtId);
}