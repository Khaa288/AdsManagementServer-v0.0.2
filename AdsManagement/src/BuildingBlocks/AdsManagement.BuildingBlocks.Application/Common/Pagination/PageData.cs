namespace AdsManagement.BuildingBlocks.Application.Common.Pagination;

public class PageData
{
    public int PageNumber { get; }

    public int PageSize { get; }

    public int TotalPages { get; }

    public int TotalCount { get; }

    public bool HasPrevious => PageNumber > 0;

    public bool HasNext => PageNumber < TotalPages - 1;

    public PageData(int count, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;
    }
}