using ERP.EvaluationManagement.Core.Entity;
using ERP.EvaluationManagement.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.EvaluationManagement.DataService.Repositories;

public class StudentResultRepository : GenericRepository<StudentResult>, IStudentResultRepository
{
    public StudentResultRepository(AppDbContext context, ILogger logger) : base(context, logger)
    {
    }
    
    public override async Task<IEnumerable<StudentResult>> GetAllAsync()
    {
        try
        {
            return await _dbSet
                .Where(x => x.Status == 1)
                .Include(x => x.Student)
                .Include(x => x.Evaluation)
                .OrderBy(x => x.AddedDate)
                .ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} GetAllAsync Error", typeof(StudentResultRepository));
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
            _logger.LogError(e, "{Repo} DeleteAsync Error", typeof(ModuleRegistrationRepository));
            throw;
        }
    }

    public async Task<IEnumerable<StudentResult>> GetEvaluationResultAsync(Guid evaluationId)
    {
        try
        {
            return await _dbSet
                .Where(x => x.EvaluationId == evaluationId)
                .Include(x => x.Student)
                .Include(x => x.Evaluation)
                .OrderBy(x => x.AddedDate)
                .ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} GetEvaluationResultAsync Error", typeof(StudentResultRepository));
            throw;
        }
    }

    public async Task<StudentResult> GetStudentResultIdAsync(Guid evaluationId, Guid studentId)
    {
        try
        {
            return await _dbSet
                .FirstOrDefaultAsync(x => x.EvaluationId == evaluationId && x.StudentId == studentId);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} GetStudentResultIdAsync Error", typeof(StudentResultRepository));
            throw;
        }
    }

    public override async Task<bool> UpdateAsync(StudentResult entity)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (result == null) return false;

            result.StudentId = entity.StudentId;
            result.EvaluationId = entity.EvaluationId;
            result.StudentScore = entity.StudentScore;
            result.UpdateDate = DateTime.UtcNow;

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Update function error",
                typeof(StudentResultRepository));
            throw;
        }
    }

    public async Task<IEnumerable<StudentResult>> GetAllStudentResultsOfParticularModuleOfferingAsync(Guid moduleOfferingId)
    {
        try
        {
            return await _dbSet
                .Where(x => x.Status == 1 && x.Evaluation.ModuleOfferingID == moduleOfferingId && x.Evaluation.Status == 1)
                .Include(x => x.Student)
                .Include(x => x.Evaluation)
                .OrderBy(x => x.AddedDate)
                .ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} GetAllAsync Error", typeof(StudentResultRepository));
            throw;
        }
    }
    
}