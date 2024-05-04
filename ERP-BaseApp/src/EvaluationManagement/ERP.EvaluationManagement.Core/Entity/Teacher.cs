using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.EvaluationManagement.Core.Entity
{
    public class Teacher : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty; 
        public string LastName { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty; 
        
        [InverseProperty("Coordinator")] 
        public virtual ICollection<ModuleOffering> CordinatingModules {  get; set; } 
        public virtual ICollection<ModuleOfferingTeacher> TeachingModules { get; set; } 
        public virtual ICollection<ModuleOfferingFirstExaminer> FirstExaminersModules { get; set; } 
        public virtual ICollection<ModuleOfferingSecondExaminer> SecondExaminersModules { get; set; } 
        public virtual ICollection<Student> AcademicAdvicees { get; set; } 

    }
}