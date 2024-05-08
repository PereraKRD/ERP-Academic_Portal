using ERP.RequestManagement.DataService.Repositories.Interfaces;

namespace ERP.RequestManagement.DataService.Repositories.Interfaces;

public interface IUnitOfWork
{
    public ITeacherRepository Teachers { get; }
    public IStudentRepository Students { get; }
    public IBatchRepository Batches { get; }
    public ITeacherRequestRepository TeacherRequests { get; }
    public IStudentRequestRepository StudentRequests { get; }
    Task<bool> CompleteAsync();
}