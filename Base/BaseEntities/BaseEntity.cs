namespace FarmControl.Base.BaseEntities;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public DateTimeOffset DeletedAt { get; set; }
    public bool IsDeleted { get; set; }
    public long Version { get; set; }
}