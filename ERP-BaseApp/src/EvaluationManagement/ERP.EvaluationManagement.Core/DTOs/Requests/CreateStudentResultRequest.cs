namespace ERP.EvaluationManagement.Core.DTOs.Requests;

public class CreateStudentResultRequest
{
    public Guid StudentId { get; set; }
    public Guid EvaluationId { get; set; }
    public double StudentScore { get; set; }

}