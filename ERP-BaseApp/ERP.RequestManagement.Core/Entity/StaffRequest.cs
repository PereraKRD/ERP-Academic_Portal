using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.RequestManagement.Core.Entity
{
    public class StaffRequest : BaseEntity
    {
        public string? Message { get; set; }
        public Guid SenderId { get; set; }
        [ForeignKey("SenderId")]
        public Teacher Sender { get; set; }
        public Guid RecieverId { get; set; }
        [ForeignKey("RecieverId")]
        public Teacher Reciever { get; set; }
        public bool? IsChecked { get; set; }
        public int Header { get; set; }
    }
}
