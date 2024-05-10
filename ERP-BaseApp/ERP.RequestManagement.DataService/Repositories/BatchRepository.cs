
using ERP.RequestManagement.DataService.Repositories.Interfaces;
using ERP.RequestManagement.Core.Entity;
using ERP.RequestManagement.DataService.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.RequestManagement.DataService.Repositories
{
    public class BatchRepository : GenericRepository<Batch> , IBatchRepository
    {
        public BatchRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Batch>> GetAllAsync()
        {
            try
            {
                return await _dbSet.Where(x => x.Status == 1)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(x => x.AddedDate)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetAllAsync Error", typeof(BatchRepository));
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
                _logger.LogError(e, "{Repo} DeleteAsync Error", typeof(BatchRepository));
                throw;
            }
        }
    }
}
