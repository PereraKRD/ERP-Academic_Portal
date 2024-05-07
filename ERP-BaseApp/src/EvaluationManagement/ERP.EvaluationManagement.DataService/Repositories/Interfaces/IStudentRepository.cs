using ERP.EvaluationManagement.Core.Entity;

namespace ERP.EvaluationManagement.DataService.Repositories.Interfaces;

public interface IStudentRepository : IGenericRepository<Student>
{
    Task<IEnumerable<Student>> GetAcademicAdviceeListAsync(Guid batchId, Guid advisorId);
    Task<Student> GetStudentByRegNum(string RegNum);
}