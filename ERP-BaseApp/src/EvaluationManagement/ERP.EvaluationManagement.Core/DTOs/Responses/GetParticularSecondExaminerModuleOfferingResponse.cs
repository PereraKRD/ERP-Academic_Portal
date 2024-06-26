namespace ERP.EvaluationManagement.Core.DTOs.Responses;

public class GetParticularSecondExaminerModuleOfferingResponse
{
    public Guid ModuleOfferingId { get; set; }
    public string ModuleName { get; set; }  = string.Empty;
    public string ModuleCode { get; set; } = string.Empty;
    public string SecondExaminerName { get; set; } = string.Empty;
    public string Semester { get; set; } = string.Empty;
}