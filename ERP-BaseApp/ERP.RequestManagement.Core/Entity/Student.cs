

using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.RequestManagement.Core.Entity
{
    public class Student : BaseEntity
    {
        public string RegistrationNum { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid? AcademicAdvisorId { get; set; }
        [ForeignKey("AcademicAdvisorId")]
        public Teacher? AcademicAdvisor { get; set; }
        
    }
}
