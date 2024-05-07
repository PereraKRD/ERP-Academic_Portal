using AutoMapper;
using ERP.RequestManagement.Core.DTOs.Responses;
using ERP.RequestManagement.Core.Entity;

namespace ERP.RequestManagement.Api.MappingProfiles;

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
            ;
        
        CreateMap<Student, GetStudentResponse>()
            .ForMember(dest => dest.StudentId,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FullName,
                opt => opt
                    .MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.Email,
                opt => opt
                    .MapFrom(src => src.Email))
            ;
        

    }
}