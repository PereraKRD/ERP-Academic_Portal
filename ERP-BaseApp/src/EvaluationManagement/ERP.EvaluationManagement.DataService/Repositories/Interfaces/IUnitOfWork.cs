namespace ERP.EvaluationManagement.DataService.Repositories.Interfaces;

public interface IUnitOfWork
{
    public IEvaluationRepository Evaluations { get; }
    public IModuleOfferingRepository ModuleOfferings { get; }
    public ITeacherRepository Teachers { get; }
    public IModuleRepository Modules { get; }
    public IStudentRepository Students { get; }
    public IModuleRegistrationRepository ModuleRegistrations { get; }
    public IStudentResultRepository StudentResults { get; }
    public IFirstExaminerModuleOfferingRepository FirstExaminerModuleOfferings { get; }
    public ISecondExaminerModuleOfferingRepository SecondExaminerModuleOfferings { get; }
    Task<bool> CompleteAsync();
}