using ERP.EvaluationManagement.Core.Entity;
using ERP.EvaluationManagement.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.EvaluationManagement.DataService.Repositories;

public class SecondExaminerModuleOfferingRepository : GenericRepository<ModuleOfferingSecondExaminer> , ISecondExaminerModuleOfferingRepository
{
    public SecondExaminerModuleOfferingRepository(AppDbContext context, ILogger logger) : base(context, logger)
    {
    }

    public override async Task<IEnumerable<ModuleOfferingSecondExaminer>> GetAllAsync()
    {
        try
        {
            return await _dbSet
                .Where(x => x.Status == 1)
                .Include(x => x.ModuleOffering.Module)
                .Include(x => x.Teacher)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.AddedDate)
                .ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} GetAllAsync Error", typeof(SecondExaminerModuleOfferingRepository));
            throw;
        }
    }
}