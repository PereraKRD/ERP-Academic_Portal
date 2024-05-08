using AutoMapper;
using ERP.RequestManagement.Core.DTOs.Requests;
using ERP.RequestManagement.Core.Entity;

namespace ERP.RequestManagement.Api.MappingProfiles;

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
        
        CreateMap<CreateStudentRequest, Student>()
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

        CreateMap<CreateTeacherMessageRequest, TeacherRequest>()
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdateDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            ;

        CreateMap<CreateStudentMessageRequest, StudentRequest>()
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdateDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            ;
    }
}