namespace ERP.EvaluationManagement.Core.DTOs.Responses;

public class GetModuleRegistrationResponse
{
    public Guid StudentId { get; set; }
    public Guid ModuleOfferingId { get; set; }
    public string ModuleName { get; set; } = string.Empty;
    public string StudentRegistrationNum { get; set; } = string.Empty;
    public string StudentName { get; set; } = string.Empty;
    public string StudentEmail { get; set; } = string.Empty;
    
}