namespace ERP.EvaluationManagement.Core.DTOs.Responses;

public class GetParticularFirstExaminerModuleOfferingResponse
{
    public Guid ModuleOfferingId { get; set; }
    public string ModuleName { get; set; } = string.Empty;
    public string ModuleCode { get; set; } = string.Empty;
    public string FirstExaminerName { get; set; } = string.Empty;
    public string Semester { get; set; } = string.Empty;
}