using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.EvaluationManagement.Core.Entity
{
    public class ModuleOfferingSecondExaminer
    {
        public Guid ModuleOfferingId { get; set; }
        [ForeignKey("ModuleOfferingId")]
        public virtual ModuleOffering ModuleOffering { get; set; }
        public Guid TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }
    }
}