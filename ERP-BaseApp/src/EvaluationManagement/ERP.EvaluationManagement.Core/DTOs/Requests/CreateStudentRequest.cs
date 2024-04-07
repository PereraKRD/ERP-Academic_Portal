namespace ERP.EvaluationManagement.Core.DTOs.Requests;

public class CreateStudentRequest
{
    public string RegistrationNum { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}