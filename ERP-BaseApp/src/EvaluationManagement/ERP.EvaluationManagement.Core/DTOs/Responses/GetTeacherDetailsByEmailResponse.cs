namespace ERP.EvaluationManagement.Core.DTOs.Responses;

public class GetTeacherDetailsByEmailResponse
{
    public Guid TeacherId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}