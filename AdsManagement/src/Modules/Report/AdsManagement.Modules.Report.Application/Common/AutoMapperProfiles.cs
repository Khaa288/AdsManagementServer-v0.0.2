using AdsManagement.Modules.Report.Application.Commands;

using AutoMapper;

namespace AdsManagement.Modules.Report.Application.Common;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Domain.Entities.Report, SendReportResponse>()
            .ForMember(sr => sr.ObjectType, r => r.MapFrom(r => r.ReportObject.ObjectType))
            .ForMember(sr => sr.Address, r => r.MapFrom(r => r.ReportObject.Address))
            .ForMember(sr => sr.DistrictName, r => r.MapFrom(r => r.ReportObject.DistrictName))
            .ForMember(sr => sr.WardName, r => r.MapFrom(r => r.ReportObject.WardName))
            .ForMember(sr => sr.ReporterName, r => r.MapFrom(r => r.Reporter.Name))
            .ForMember(sr => sr.ReporterEmail, r => r.MapFrom(r => r.Reporter.Email))
            .ForMember(sr => sr.ReporterPhoneNumber, r => r.MapFrom(r => r.Reporter.PhoneNumber));
    }
}