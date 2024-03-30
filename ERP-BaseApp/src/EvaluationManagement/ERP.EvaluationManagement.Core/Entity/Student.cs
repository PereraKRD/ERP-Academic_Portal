namespace ERP.EvaluationManagement.Core.Entity
{
    public class Student : BaseEntity
    {
        public string RegistrationNum { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        
        public virtual ICollection<StudentResult> StudentResults { get; set; } = new List<StudentResult>();
        public virtual ICollection<ModuleRegistration> ModuleRegistrations { get; set; } = new List<ModuleRegistration>();
        
    }
}
