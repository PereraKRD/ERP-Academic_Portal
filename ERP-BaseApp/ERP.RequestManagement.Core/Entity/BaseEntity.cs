namespace ERP.RequestManagement.Core.Entity;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    public int Status { get; set; }
}