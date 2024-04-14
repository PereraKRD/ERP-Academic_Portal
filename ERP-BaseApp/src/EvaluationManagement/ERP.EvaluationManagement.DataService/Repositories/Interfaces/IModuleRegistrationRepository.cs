using ERP.EvaluationManagement.Core.Entity;

namespace ERP.EvaluationManagement.DataService.Repositories.Interfaces;

public interface IModuleRegistrationRepository : IGenericRepository<ModuleRegistration>
{
    Task<IEnumerable<ModuleRegistration>> GetModuleRegistrationByModuleOfferingAsync(Guid moduleOfferingId);
}