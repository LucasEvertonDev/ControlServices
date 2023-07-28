using ControlServices.Core.Domain.IEntities;

namespace ControlServices.Core.Domain.Entities;

public class BaseEntity : IEntity
{
    public Guid Id { get; set; }

    public DateTime CreateDate { get; set; } = DateTime.Now;

    public DateTime UpdateDate { get; set; } = DateTime.Now;
}
