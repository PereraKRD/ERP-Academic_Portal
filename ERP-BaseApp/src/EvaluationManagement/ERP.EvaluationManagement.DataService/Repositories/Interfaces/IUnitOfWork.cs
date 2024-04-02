namespace ERP.EvaluationManagement.DataService.Repositories.Interfaces;

public interface IUnitOfWork
{
    public IEvaluationRepository Evaluations { get; }
    public IModuleOfferingRepository ModuleOfferings { get; }
    public ITeacherRepository Teachers { get; }
    public IModuleRepository Modules { get; }
    Task<bool> CompleteAsync();
}