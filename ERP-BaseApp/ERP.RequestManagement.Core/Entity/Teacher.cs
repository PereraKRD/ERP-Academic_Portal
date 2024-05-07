

using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.RequestManagement.Core.Entity
{
    public class Teacher : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty; 
        public string LastName { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty; 
        
        public virtual ICollection<Student> AcademicAdvicees { get; set; } 

    }
}