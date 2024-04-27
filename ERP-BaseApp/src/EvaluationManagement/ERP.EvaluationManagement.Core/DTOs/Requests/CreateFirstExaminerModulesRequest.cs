namespace ERP.EvaluationManagement.Core.DTOs.Requests;

public class CreateFirstExaminerModulesRequest
{
    public Guid ModuleOfferingId { get; set; }
    public Guid TeacherId { get; set; }

}