
using ERP.RequestManagement.DataService.Repositories.Interfaces;
using ERP.RequestManagement.Core.Entity;

namespace ERP.RequestManagement.DataService.Repositories.Interfaces;

public interface IStudentRepository : IGenericRepository<Student>
{
    Task<IEnumerable<Student>> GetAcademicAdviceeListAsync(Guid batchId, Guid advisorId);
    Task<Student> GetStudentByRegNum(string RegNum);
}