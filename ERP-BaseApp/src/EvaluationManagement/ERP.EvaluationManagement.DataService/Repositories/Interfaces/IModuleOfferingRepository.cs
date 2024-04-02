using ERP.EvaluationManagement.Core.Entity;

namespace ERP.EvaluationManagement.DataService.Repositories.Interfaces;

public interface IModuleOfferingRepository : IGenericRepository<ModuleOffering>
{
    Task<IEnumerable<ModuleOffering>> GetTeacherModulesAsync(Guid id);

    //Task<IQueryable<ModuleOfferingFirstExaminer>> GetFirstExaminerModulesAsync(Guid teacherId);
    //Task<IQueryable<ModuleOfferingSecondExaminer>> GetSecondExaminerModulesAsync(Guid teacherId);
}