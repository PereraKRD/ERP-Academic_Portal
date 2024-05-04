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
            .ForMember(dest => dest.Semester,
                opt => opt.MapFrom(src => src.Module.Semester))
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

        CreateMap<Evaluation, GetEvaluationDetailsResponse>()
            .ForMember(dest => dest.EvaluationId,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.EvaluationName,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(opt => opt.EvaluationType,
                opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.EvaluationMarks,
                opt => opt.MapFrom(src => src.Marks))
            .ForMember(dest => dest.EvaluationFinalMarks,
                opt => opt.MapFrom(src => src.FinalMarks))
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
            .ForMember(dest => dest.AcademicAdvisorName, opt => opt.MapFrom(src => $"{src.AcademicAdvisor.FirstName} {src.AcademicAdvisor.LastName}" ))
            .ForMember(dest => dest.BatchName, opt => opt.MapFrom(src => src.Batch.BatchName))
            ;
        
        CreateMap<ModuleRegistration, GetModuleRegistrationResponse>()
            .ForMember(dest => dest.ModuleName,
                opt => opt.MapFrom(src => src.ModuleOffering.Module.Name))
            .ForMember(dest => dest.StudentRegistrationNum,
                opt => opt.MapFrom(src => src.Student.RegistrationNum))
            .ForMember(dest => dest.StudentName,
                opt => opt
                    .MapFrom(src => $"{src.Student.FirstName} {src.Student.LastName}"))
            .ForMember(dest => dest.StudentEmail,
                opt => opt
                    .MapFrom(src => src.Student.Email))
            ;
        
        CreateMap<StudentResult, GetStudentResultResponse>()
            .ForMember(dest => dest.RegistrationNum,
                opt => opt.MapFrom(src => src.Student.RegistrationNum))
            .ForMember(dest => dest.FullName,
                opt => opt
                    .MapFrom(src => $"{src.Student.FirstName} {src.Student.LastName}"))
            ;
        
        CreateMap<StudentResult, GetEvaluationResultListResponse>()
            .ForMember(dest => dest.RegistrationNum,
                opt => opt.MapFrom(src => src.Student.RegistrationNum))
            .ForMember(dest => dest.FullName,
                opt => opt
                    .MapFrom(src => $"{src.Student.FirstName} {src.Student.LastName}"))
            ;
        
        CreateMap<ModuleRegistration, GetModuleOfferingStudentsResponse>()
            .ForMember(dest => dest.RegistrationNum,
                opt => opt.MapFrom(src => src.Student.RegistrationNum))
            .ForMember(dest => dest.FullName,
                opt => opt
                    .MapFrom(src => $"{src.Student.FirstName} {src.Student.LastName}"))
            .ForMember(dest => dest.Email,
                opt => opt
                    .MapFrom(src => src.Student.Email))
            ;
        
        CreateMap<ModuleOfferingFirstExaminer, GetAllFirstExaminerModuleOfferingResponse>()
            .ForMember(dest => dest.ModuleOfferingId,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ModuleName,
                opt => opt.MapFrom(src => src.ModuleOffering.Module.Name))
            .ForMember(dest => dest.ModuleCode,
                opt => opt.MapFrom(src => src.ModuleOffering.Module.Code))
            .ForMember(dest => dest.FirstExaminerName,
                opt => opt
                    .MapFrom(src => $"{src.Teacher.FirstName} {src.Teacher.LastName}"))
            ;
        
        CreateMap<ModuleOfferingSecondExaminer, GetAllSecondExaminerModuleOfferingResponse>()
            .ForMember(dest => dest.ModuleOfferingId,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ModuleName,
                opt => opt.MapFrom(src => src.ModuleOffering.Module.Name))
            .ForMember(dest => dest.ModuleCode,
                opt => opt.MapFrom(src => src.ModuleOffering.Module.Code))
            .ForMember(dest => dest.SecondExaminerName,
                opt => opt
                    .MapFrom(src => $"{src.Teacher.FirstName} {src.Teacher.LastName}"))
            ;
        
        CreateMap<ModuleOfferingFirstExaminer, GetParticularFirstExaminerModuleOfferingResponse>()
            .ForMember(dest => dest.ModuleOfferingId,
                opt => opt.MapFrom(src => src.ModuleOfferingId))
            .ForMember(dest => dest.ModuleName,
                opt => opt.MapFrom(src => src.ModuleOffering.Module.Name))
            .ForMember(dest => dest.ModuleCode,
                opt => opt.MapFrom(src => src.ModuleOffering.Module.Code))
            .ForMember(dest => dest.FirstExaminerName,
                opt => opt
                    .MapFrom(src => $"{src.Teacher.FirstName} {src.Teacher.LastName}"))
            .ForMember(dest => dest.Semester,
                opt => opt.MapFrom(src => src.ModuleOffering.Module.Semester))
            ;
        
        CreateMap<ModuleOfferingSecondExaminer, GetParticularSecondExaminerModuleOfferingResponse>()
            .ForMember(dest => dest.ModuleOfferingId,
                opt => opt.MapFrom(src => src.ModuleOfferingId))
            .ForMember(dest => dest.ModuleName,
                opt => opt.MapFrom(src => src.ModuleOffering.Module.Name))
            .ForMember(dest => dest.ModuleCode,
                opt => opt.MapFrom(src => src.ModuleOffering.Module.Code))
            .ForMember(dest => dest.SecondExaminerName,
                opt => opt.MapFrom(src => $"{src.Teacher.FirstName} {src.Teacher.LastName}"))
            .ForMember(dest => dest.Semester,
                opt => opt.MapFrom(src => src.ModuleOffering.Module.Semester))
            ;

        CreateMap<Batch, GetBatchResponse>()
            .ForMember(dest => dest.BatchId,
                opt => opt.MapFrom(src => src.Id))
            ;

    }
}