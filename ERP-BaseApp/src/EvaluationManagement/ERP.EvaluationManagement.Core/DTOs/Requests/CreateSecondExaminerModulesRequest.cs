namespace ERP.EvaluationManagement.Core.DTOs.Requests;

public class CreateSecondExaminerModulesRequest
{
    public Guid ModuleOfferingId { get; set; }
    public Guid TeacherId { get; set; }
}