using AutoMapper;
using ERP.EvaluationManagement.Core.DTOs.Requests;
using ERP.EvaluationManagement.Core.Entity;

namespace ERP.EvaluationManagement.Api.MappingProfiles;

public class RequestToDomain : Profile
{
    public RequestToDomain()
    {
        CreateMap<CreateTeacherRequest, Teacher>()
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdateDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            ;
        
        CreateMap<CreateModuleRequest, Module>()
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdateDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            ;
        
        CreateMap<CreateModuleOfferingRequest, ModuleOffering>()
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdateDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            ;
        
        CreateMap<CreateEvaluationRequest, Evaluation>()
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdateDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            ;
        
        CreateMap<CreateStudentRequest, Student>()
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdateDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            ;
        
        CreateMap<CreateModuleRegistrationRequest, ModuleRegistration>()
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdateDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            ;
        
        CreateMap<CreateStudentResultRequest, StudentResult>()
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdateDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            ;
        
        CreateMap<UpdateEvaluationRequest, Evaluation>()
            .ForMember( dest => dest.Id,
                opt => opt.MapFrom(src => src.EvaluationId))
            .ForMember(dest => dest.UpdateDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            ;
        
        CreateMap<CreateFirstExaminerModulesRequest, ModuleOfferingFirstExaminer>()
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdateDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            ;

        CreateMap<CreateSecondExaminerModulesRequest, ModuleOfferingSecondExaminer>()
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdateDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            ;

        CreateMap<CreateBatchRequest, Batch>()
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdateDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            ;
    }
}