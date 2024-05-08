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
            .ForMember(dest => dest.AcademicAdvisorName, opt => opt.MapFrom(src => $"{src.AcademicAdvisor.FirstName} {src.AcademicAdvisor.LastName}"))
            .ForMember(dest => dest.BatchName, opt => opt.MapFrom(src => src.Batch.BatchName))
            ;

        CreateMap<Batch, GetBatchResponse>()
            .ForMember(dest => dest.BatchId,
                opt => opt.MapFrom(src => src.Id))
            ;

        CreateMap<StudentRequest, GetStudentMessagesResponse>()
             .ForMember(dest => dest.RequestId,
                 opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.Sender.FirstName))
             .ForMember(dest => dest.RecieverName, opt => opt.MapFrom(src => src.Reciever.FirstName))
             ;

        CreateMap<TeacherRequest, GetTeacherMessagesResponse>()
             .ForMember(dest => dest.RequestId,
                 opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.Sender.FirstName))
             .ForMember(dest => dest.RecieverName, opt => opt.MapFrom(src => src.Reciever.FirstName))
             ;
    }
}