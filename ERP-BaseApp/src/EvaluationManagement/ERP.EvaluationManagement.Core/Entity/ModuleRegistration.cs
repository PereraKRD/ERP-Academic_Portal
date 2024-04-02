using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.EvaluationManagement.Core.Entity
{
    public class ModuleRegistration : BaseEntity
    {
        public Guid StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        
        public Guid ModuleOfferingId { get; set; }
        [ForeignKey("ModuleOfferingId")]
        public virtual ModuleOffering ModuleOffering { get; set; }


    }
}