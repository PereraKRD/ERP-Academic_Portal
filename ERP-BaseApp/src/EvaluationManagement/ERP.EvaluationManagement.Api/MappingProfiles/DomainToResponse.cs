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
        
        CreateMap<ModuleOffering, GetTeacherModulesResponse>()
            .ForMember(dest => dest.ModuleOfferingId,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Module.Name))
            .ForMember(dest => dest.Code,
                opt => opt.MapFrom(src => src.Module.Code))
            ;
        
        CreateMap<ModuleOffering, GetModuleOfferingDetailsResponse>()
            .ForMember(dest => dest.ModuleOfferingId,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ModuleName,
                opt => opt.MapFrom(src => src.Module.Name))
            .ForMember(dest => dest.ModuleCode,
                opt => opt.MapFrom(src => src.Module.Code))
            .ForMember(dest => dest.CoordinatorName,
                opt => opt
                    .MapFrom(src => $"{src.Coordinator.FirstName} {src.Coordinator.LastName}"))
            ;
        
        
    }
}