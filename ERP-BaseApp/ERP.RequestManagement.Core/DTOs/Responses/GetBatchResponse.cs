
using ERP.RequestManagement.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.RequestManagement.Core.DTOs.Responses
{
    public class GetBatchResponse
    {
        public Guid BatchId { get; set; }
        public string? BatchName { get; set; }
        public ICollection<Student> BatchStudents { get; set; }
    }
}
