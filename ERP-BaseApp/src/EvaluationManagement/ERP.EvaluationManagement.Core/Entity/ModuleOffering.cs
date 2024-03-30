namespace ERP.EvaluationManagement.Core.Entity
{
    public class ModuleOffering : BaseEntity
    {
        public virtual Module Module { get; set; }  
        public virtual Teacher Coordinator { get; set; }
        public virtual Teacher Moderator { get; set; }
        public virtual Teacher ExternalModerator { get; set; }
        public virtual ICollection<ModuleOfferingTeacher> Teachers { get; set; } = new List<ModuleOfferingTeacher>();
        public virtual ICollection<ModuleOfferingFirstExaminer> FirstExaminers { get; set; } =
            new List<ModuleOfferingFirstExaminer>();
        public virtual ICollection<ModuleOfferingSecondExaminer> SecondExaminers { get; set; } =
            new List<ModuleOfferingSecondExaminer>();
        public virtual ICollection<ModuleRegistration> Registrations { get; set; } = new List<ModuleRegistration>();
        public virtual ICollection<Evaluation> Evalutions { get; set; } = new List<Evaluation>();
    }
}
