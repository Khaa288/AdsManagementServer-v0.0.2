namespace AdsManagement.BuildingBlocks.Application.Common.Pagination;

public class PagedList<T> : List<T>
{
    public PageData PageData { get; }

    public PagedList(List<T> items, int count, int pageNumber, int pageSize)
    {
        PageData = new PageData(count, pageNumber, pageSize);
        AddRange(items);
    }
}