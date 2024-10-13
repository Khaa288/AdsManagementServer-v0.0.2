using AdsManagement.BuildingBlocks.Application.Common.Files;

using AutoMapper;

namespace AdsManagement.API.Common;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile() {
        CreateMap<IFormFile, FileData>()
            .ForMember(
                fd => fd.Content, 
                ff => ff.MapFrom((ff => ff.OpenReadStream())));
    }
}