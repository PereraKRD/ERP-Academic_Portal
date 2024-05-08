using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.RequestManagement.Core.Entity
{
    public class TeacherRequest : BaseEntity
    {
        public string? Message { get; set; }
        public Guid SenderId { get; set; }
        [ForeignKey("SenderId")]
        public Teacher Sender { get; set; }
        public Guid RecieverId { get; set; }
        [ForeignKey("RecieverId")]
        public Student Reciever { get; set; }
        public bool? IsChecked { get; set; }
    }
}
