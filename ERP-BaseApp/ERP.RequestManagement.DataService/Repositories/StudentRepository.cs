using ERP.RequestManagement.Core.Entity;
using ERP.RequestManagement.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.RequestManagement.DataService.Repositories;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(AppDbContext context, ILogger logger) : base(context, logger)
    {
    }

    public override async Task<IEnumerable<Student>> GetAllAsync()
    {
        try
        {
            return await _dbSet.Where(x => x.Status == 1)
                .Include(x => x.AcademicAdvisor)
                .Include(x => x.Batch)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.AddedDate)
                .ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} GetAllAsync Error", typeof(StudentRepository));
            throw;
        }
    }

    public async Task<IEnumerable<Student>> GetAcademicAdviceeListAsync(Guid batchId, Guid advisorId)
    {
        try
        {
            return _dbSet
                    .Where(x => x.BatchId == batchId)
                    .Where(x => x.AcademicAdvisorId == advisorId)
                    .Include(x => x.AcademicAdvisor)
                    .Include(x => x.Batch)
                ;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} GetAcademicAdviceeListAsync Error", typeof(StudentRepository));
            throw;
        }
    }

    public async Task<Student> GetStudentByRegNum(string RegNum)
    {
        try
        {
            return await _dbSet
                .FirstOrDefaultAsync(x => x.RegistrationNum == RegNum);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} DeleteAsync Error", typeof(StudentRepository));
            throw;
        }
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null) return false;

            result.Status = 0;
            result.UpdateDate = DateTime.UtcNow;
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} DeleteAsync Error", typeof(StudentRepository));
            throw;
        }
    }
}