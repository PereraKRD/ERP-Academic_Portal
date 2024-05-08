using ERP.EvaluationManagement.Core.Entity;

namespace ERP.EvaluationManagement.DataService.Repositories.Interfaces;

public interface IEvaluationRepository : IGenericRepository<Evaluation>
{
    Task<IEnumerable<Evaluation>> GetByIdAsync(Guid moduleOfferingId);
    Task<Evaluation> GetByEvaluationIdAsync(Guid evaluationId);
}