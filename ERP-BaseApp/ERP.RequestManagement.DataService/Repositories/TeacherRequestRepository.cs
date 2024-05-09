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
    public class TeacherRequestRepository : GenericRepository<TeacherRequest>, ITeacherRequestRepository
    {
        public TeacherRequestRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<TeacherRequest>> GetAllAsync()
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
                _logger.LogError(e, "{Repo} GetAllAsync Error", typeof(TeacherRequestRepository));
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
                _logger.LogError(e, "{Repo} DeleteAsync Error", typeof(TeacherRequestRepository));
                throw;
            }
        }

        public async Task<IEnumerable<TeacherRequest>> GetTeacherRequestsByTeacherIdAsync(Guid teacherId)
        {
            try
            {
                return _dbSet
                        .Where(x => x.SenderId == teacherId)
                        .Include(x => x.Sender)
                        .Include(x => x.Reciever)
                    ;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetAcademicAdviceeListAsync Error", typeof(TeacherRequestRepository));
                throw;
            }
        }


        public async Task<TeacherRequest> GetTeacherRequestByRequestIdAsync(Guid requestId)
        {
            try
            {
                return await _dbSet
                        .Where(x => x.Id == requestId)
                        .Include(x => x.Sender)
                        .Include(x => x.Reciever)
                        .FirstOrDefaultAsync()
                ;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetAcademicAdviceeListAsync Error", typeof(StudentRequestRepository));
                throw;
            }
        }

    }
}
