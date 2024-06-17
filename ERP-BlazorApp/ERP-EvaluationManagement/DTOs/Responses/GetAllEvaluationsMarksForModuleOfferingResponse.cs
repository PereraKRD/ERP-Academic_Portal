namespace ERP_EvaluationManagement.DTOs.Responses;

public class GetAllEvaluationsMarksForModuleOfferingResponse
{
    public Guid StudentId { get; set; }
    public Guid EvaluationId { get; set; }
    public string EvaluationName { get; set; } = string.Empty;
    public string RegistrationNum { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public double StudentScore { get; set; }
}
