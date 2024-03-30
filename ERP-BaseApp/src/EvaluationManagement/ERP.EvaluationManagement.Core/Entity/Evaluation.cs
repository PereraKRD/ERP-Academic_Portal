using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.EvaluationManagement.Core.Entity
{
    public class Evaluation : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int Type {  get; set; }
        public double FinalMarks { get; set; }
        public double Marks { get; set; }
        
        public Guid ModuleOfferingID { get; set; }
        [ForeignKey("ModuleOfferingID")]
        public virtual ModuleOffering ModuleOffering { get; set; }
        public virtual ICollection<StudentResult> Results { get; set; }

    }
}