using ERP.RequestManagement.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.RequestManagement.DataService.Repositories.Interfaces
{
    public interface IStaffRequestRepository : IGenericRepository<StaffRequest>
    {
        Task<IEnumerable<StaffRequest>> GetStaffRequestsBySenderIdAsync(Guid teacherId);
        Task<IEnumerable<StaffRequest>> GetStaffRequestsByRecieverIdAsync(Guid teacherId);
        Task<StaffRequest> GetStaffRequestByRequestIdAsync(Guid requestId);
    }
}
