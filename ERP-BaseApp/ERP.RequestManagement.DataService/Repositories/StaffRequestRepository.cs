using ERP.RequestManagement.Core.Entity;
using ERP.RequestManagement.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.RequestManagement.DataService.Repositories
{
    public class StaffRequestRepository : GenericRepository<StaffRequest>, IStaffRequestRepository
    {
        public StaffRequestRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<StaffRequest>> GetAllAsync()
        {
            try
            {
                return await _dbSet.Where(x => x.Status == 1)
                    .Include(x => x.Sender)
                    .Include(x => x.Reciever)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(x => x.AddedDate)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetAllAsync Error", typeof(StaffRequestRepository));
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
                _logger.LogError(e, "{Repo} DeleteAsync Error", typeof(StaffRequestRepository));
                throw;
            }
        }

        public async Task<IEnumerable<StaffRequest>> GetStaffRequestsBySenderIdAsync(Guid teacherId)
        {
            try
            {
                return _dbSet
                        .Where(x => x.SenderId == teacherId && x.Status == 1)
                        .Include(x => x.Sender)
                        .Include(x => x.Reciever)
                    ;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetStaffRequestsBySenderIdAsync Error", typeof(StaffRequestRepository));
                throw;
            }
        }

        public async Task<IEnumerable<StaffRequest>> GetStaffRequestsByRecieverIdAsync(Guid teacherId)
        {
            try
            {
                return _dbSet
                        .Where(x => x.RecieverId == teacherId && x.Status == 1)
                        .Include(x => x.Sender)
                        .Include(x => x.Reciever)
                    ;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetStaffRequestsByRecieverIdAsync Error", typeof(StaffRequestRepository));
                throw;
            }
        }


        public async Task<StaffRequest> GetStaffRequestByRequestIdAsync(Guid requestId)
        {
            try
            {
                return await _dbSet
                        .Where(x => x.Id == requestId && x.Status == 1)
                        .Include(x => x.Sender)
                        .Include(x => x.Reciever)
                        .FirstOrDefaultAsync()
                ;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetStaffRequestByRequestIdAsync Error", typeof(StaffRequestRepository));
                throw;
            }
        }
    }
}
