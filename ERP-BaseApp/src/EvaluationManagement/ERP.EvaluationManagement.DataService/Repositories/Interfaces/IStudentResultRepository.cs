using ERP.EvaluationManagement.Core.Entity;

namespace ERP.EvaluationManagement.DataService.Repositories.Interfaces;

public interface IStudentResultRepository : IGenericRepository<StudentResult>
{
    Task<IEnumerable<StudentResult>> GetEvaluationResultAsync(Guid evaluationId);
}