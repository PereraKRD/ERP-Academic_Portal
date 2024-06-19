using ERP.EvaluationManagement.Core.Entity;

namespace ERP.EvaluationManagement.DataService.Repositories.Interfaces;

public interface ITeacherRepository : IGenericRepository<Teacher>
{
    Task<Teacher?> GetTeacherByEmailAsync(string email);
}