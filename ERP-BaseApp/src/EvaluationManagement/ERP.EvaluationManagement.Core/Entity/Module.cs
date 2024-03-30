namespace ERP.EvaluationManagement.Core.Entity
{
    public class Module : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Credits { get; set; }
        public string Semester { get; set; }
        public int Type { get; set; }
    }
}
