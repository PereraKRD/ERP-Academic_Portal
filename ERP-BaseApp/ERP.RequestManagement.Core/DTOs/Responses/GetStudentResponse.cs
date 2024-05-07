namespace ERP.RequestManagement.Core.DTOs.Responses;

public class GetStudentResponse
{
    public Guid StudentId { get; set; }
    public string RegistrationNum { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
}