using AutoMapper;
using ERP.EvaluationManagement.Core.DTOs.Responses;
using ERP.EvaluationManagement.Core.Entity;

namespace ERP.EvaluationManagement.Api.MappingProfiles;

public class DomainToResponse : Profile
{
    public DomainToResponse()
    {
        
        CreateMap<Teacher, GetTeacherResponse>()
            .ForMember(dest => dest.TeacherId,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FullName,
                opt => opt
                    .MapFrom(src => $"{src.FirstName} {src.LastName}"))
            ;
        
        CreateMap<Module, GetModuleResponse>()
            .ForMember(dest => dest.ModuleId,
                opt => opt.MapFrom(src => src.Id))
            ;
        
        CreateMap<ModuleOffering, GetModuleOfferingResponse>()
            .ForMember(dest => dest.ModuleOfferingId,
                opt => opt.MapFrom(src => src.Id))
            ;
        
        
    }
}