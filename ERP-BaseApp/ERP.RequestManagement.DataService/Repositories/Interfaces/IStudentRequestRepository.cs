using ERP.RequestManagement.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.RequestManagement.DataService.Repositories.Interfaces
{
    public interface IStudentRequestRepository : IGenericRepository<StudentRequest>
    {
        Task<IEnumerable<StudentRequest>> GetStudentRequestsByTeacherIdAsync(Guid teacherId);
        Task<StudentRequest> GetStudentRequestByRequestIdAsync(Guid requestId);
    }
}
