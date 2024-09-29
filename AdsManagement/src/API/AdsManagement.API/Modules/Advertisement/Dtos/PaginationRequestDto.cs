using System.ComponentModel.DataAnnotations;

namespace AdsManagement.API.Modules.Advertisement.Dtos;

public class PaginationRequestDto
{
    [Range(0, int.MaxValue)]
    public int PageNumber { get; set; } = 0;

    [Range(1, int.MaxValue)]
    public int PageSize { get; set; } = 25;
}