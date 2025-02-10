namespace MauiWebApp.Domain;

public abstract class BaseDomainModel
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }
}
