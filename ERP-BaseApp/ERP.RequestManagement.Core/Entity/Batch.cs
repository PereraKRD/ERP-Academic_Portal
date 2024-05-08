using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.RequestManagement.Core.Entity
{
    public class Batch : BaseEntity
    {
        public string? BatchName { get; set; }
        public virtual ICollection<Student> BatchStudents { get; set; }
    }
}
