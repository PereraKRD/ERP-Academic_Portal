using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.EvaluationManagement.Core.Entity
{
    public class ModuleOffering : BaseEntity
    {
        public Guid ModuleId { get; set; }
        [ForeignKey("ModuleId")] 
        public virtual Module Module { get; set; }
        
        public Guid CoordinatorId { get; set; }
        [ForeignKey("CoordinatorId")]
        public virtual Teacher Coordinator { get; set; }
        
        public Guid ModeratorId { get; set; }
        [ForeignKey("ModeratorId")]
        public virtual Teacher Moderator { get; set; }
        
        public Guid ExternalModeratorId { get; set; }
        [ForeignKey("ExternalModeratorId")]
        public virtual Teacher ExternalModerator { get; set; }
        
        public virtual ICollection<ModuleOfferingTeacher> Teachers { get; set; } = new List<ModuleOfferingTeacher>();
        public virtual ICollection<ModuleOfferingFirstExaminer> FirstExaminers { get; set; } =
            new List<ModuleOfferingFirstExaminer>();
        public virtual ICollection<ModuleOfferingSecondExaminer> SecondExaminers { get; set; } =
            new List<ModuleOfferingSecondExaminer>();
        public virtual ICollection<ModuleRegistration> Registrations { get; set; } = new List<ModuleRegistration>();
        public virtual ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
    }
}
