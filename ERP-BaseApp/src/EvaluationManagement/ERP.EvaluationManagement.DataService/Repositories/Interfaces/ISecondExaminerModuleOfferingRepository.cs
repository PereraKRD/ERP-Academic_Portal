using ERP.EvaluationManagement.Core.Entity;

namespace ERP.EvaluationManagement.DataService.Repositories.Interfaces;

public interface ISecondExaminerModuleOfferingRepository : IGenericRepository<ModuleOfferingSecondExaminer>
{
    Task<IEnumerable<ModuleOfferingSecondExaminer>> GetSecondExaminerModulesAsync(Guid SecondExaminerId);
}