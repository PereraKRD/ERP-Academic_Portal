using ERP.EvaluationManagement.Core.Entity;
using ERP.EvaluationManagement.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.EvaluationManagement.DataService.Repositories;

public class EvaluationRepository : GenericRepository<Evaluation>, IEvaluationRepository
{
    public EvaluationRepository(AppDbContext context, ILogger logger) : base(context, logger)
    {
    }
    
    public async override Task<IEnumerable<Evaluation>> GetAllAsync()
    {
        try
        {
            return await _dbSet
                .Where(x => x.Status == 1)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.AddedDate)
                .ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} GetAllAsync Error", typeof(EvaluationRepository));
            throw;
        }
    }
    
    public async Task<IEnumerable<Evaluation>> GetByIdAsync(Guid moduleOfferingId)
    {
        try
        {
            return await _dbSet
                .Where(x => x.Status == 1 && x.ModuleOfferingID == moduleOfferingId)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.AddedDate)
                .ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} GetAllAsync Error", typeof(EvaluationRepository));
            throw;
        }
    }

    public async Task<Evaluation> GetByEvaluationIdAsync(Guid evaluationId)
    {
        try
        {
            return await _dbSet
                .FirstOrDefaultAsync(x => x.Id == evaluationId);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} GetByEvaluationIdAsync Error", typeof(EvaluationRepository));
            throw;
        }
    }

    public override async Task<bool> DeleteAsync(Guid evaluationId)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == evaluationId);

            if (result == null) return false;
            result.Status = 0;
            result.UpdateDate = DateTime.UtcNow;
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public override async Task<bool> UpdateAsync(Evaluation entity)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (result == null)
                return false;
            
            result.Name = entity.Name;
            result.Type = entity.Type;
            result.Marks = entity.Marks;
            result.FinalMarks = entity.FinalMarks;
            result.UpdateDate = DateTime.UtcNow;

            return true;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Update function error",
                typeof(EvaluationRepository));
            throw;
        }
    }
}