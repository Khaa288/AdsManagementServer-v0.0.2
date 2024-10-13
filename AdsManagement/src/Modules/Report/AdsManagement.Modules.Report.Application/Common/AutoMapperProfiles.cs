using AdsManagement.Modules.Report.Application.Commands;

using AutoMapper;

namespace AdsManagement.Modules.Report.Application.Common;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Domain.Entities.Report, SendReportResponse>();
    }
}