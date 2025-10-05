namespace AgendaFacil.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public bool isDeleted { get; set; }
}