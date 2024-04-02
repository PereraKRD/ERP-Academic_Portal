using ERP.EvaluationManagement.Core.Entity;

namespace ERP.EvaluationManagement.Core.DTOs.Responses;

public class GetTeacherModulesResponse
{
    public Guid TeacherId { get; set; }
    public IEnumerable<ModuleOffering> Modules { get; set; }
    
}