namespace ERP.EvaluationManagement.Core.DTOs.Requests;

public class CreateModuleRegistrationRequest
{
    public Guid StudentId { get; set; }
    public Guid ModuleOfferingId { get; set; }
}