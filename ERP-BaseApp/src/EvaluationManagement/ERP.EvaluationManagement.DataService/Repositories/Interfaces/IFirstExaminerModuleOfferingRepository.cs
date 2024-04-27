using ERP.EvaluationManagement.Core.Entity;

namespace ERP.EvaluationManagement.DataService.Repositories.Interfaces;

public interface IFirstExaminerModuleOfferingRepository : IGenericRepository<ModuleOfferingFirstExaminer>
{
    Task<IEnumerable<ModuleOfferingFirstExaminer>> GetFirstExaminerModulesAsync(Guid FirstExaminerId);
}