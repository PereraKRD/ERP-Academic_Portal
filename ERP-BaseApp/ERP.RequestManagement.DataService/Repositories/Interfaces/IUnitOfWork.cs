namespace ERP.RequestManagement.DataService.Repositories.Interfaces;

public interface IUnitOfWork
{
    public ITeacherRepository Teachers { get; }
    public IStudentRepository Students { get; }
    Task<bool> CompleteAsync();
}