namespace ERP.EvaluationManagement.Core.DTOs.Responses;

public class GetStudentResultResponse
{
    public Guid StudentId { get; set; }
    public Guid EvaluationId { get; set; }
    public string RegistrationNum { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public double StudentScore { get; set; } 
}