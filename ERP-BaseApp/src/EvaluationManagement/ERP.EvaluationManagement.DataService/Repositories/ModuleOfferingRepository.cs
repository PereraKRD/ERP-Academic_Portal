using ERP.EvaluationManagement.Core.Entity;
using ERP.EvaluationManagement.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.EvaluationManagement.DataService.Repositories;

public class ModuleOfferingRepository : GenericRepository<ModuleOffering> , IModuleOfferingRepository
{
    public ModuleOfferingRepository(AppDbContext context, ILogger logger) : base(context, logger)
    {
    }
    
    public override async Task<IEnumerable<ModuleOffering>> GetAllAsync()
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
            _logger.LogError(e, "{Repo} GetAllAsync Error", typeof(ModuleOfferingRepository));
            throw;
        }
    }
    
    public async Task<IEnumerable<ModuleOffering>> GetTeacherModulesAsync(Guid id)
    {
        try
        {
            return _dbSet
                    .Where(x => x.Coordinator.Id == id)
                    .Include(x => x.Module)
                ;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} GetTeacherModulesAsync Error", typeof(ModuleOfferingRepository));
            throw;
        }
    }
    
    public override async Task<ModuleOffering?> GetAsync(Guid id)
    {
        try
        {
            return await _dbSet
                .Include(m => m.Module)
                .Include(m => m.Coordinator)
                .Include(m => m.Evalutions)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} GetAsync Error", typeof(ModuleOfferingRepository));
            throw;
        }
    }
}