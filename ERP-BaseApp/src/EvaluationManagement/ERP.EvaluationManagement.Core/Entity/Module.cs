namespace ERP.EvaluationManagement.Core.Entity
{
    public class Module : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public int Credits { get; set; }
        public string Semester { get; set; } = string.Empty;
        public int Type { get; set; }
    }
}
