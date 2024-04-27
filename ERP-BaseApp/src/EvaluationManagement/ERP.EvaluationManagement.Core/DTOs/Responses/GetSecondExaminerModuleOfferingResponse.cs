namespace ERP.EvaluationManagement.Core.DTOs.Responses;

public class GetSecondExaminerModuleOfferingResponse
{
    public Guid ModuleOfferingId { get; set; }
    public string ModuleName { get; set; }
    public string ModuleCode { get; set; }
    public string FirstExaminerName { get; set; }
}