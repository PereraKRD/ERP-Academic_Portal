using ERP.EvaluationManagement.Core.Entity;

namespace ERP.EvaluationManagement.Core.DTOs.Responses;

public class GetModuleOfferingDetailsResponse
{
    public Guid ModuleOfferingId { get; set; }
    public string ModuleName { get; set; }
    public string ModuleCode { get; set; }
    public string CoordinatorName { get; set; }
    public ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
}