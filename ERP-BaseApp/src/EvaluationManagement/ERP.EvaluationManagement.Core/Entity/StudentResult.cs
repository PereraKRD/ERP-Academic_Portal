using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.EvaluationManagement.Core.Entity
{
    public class StudentResult : BaseEntity
    {
        public Guid StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        
        public Guid EvaluationId { get; set; }
        [ForeignKey("EvaluationId")]
        public virtual Evaluation Evaluation { get; set; }
        
        public double StudentScore { get; set; }
        


    }
}