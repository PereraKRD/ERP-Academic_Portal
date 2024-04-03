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
}