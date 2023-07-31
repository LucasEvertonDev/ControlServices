using ControlServices.Core.Domain.IEntities;

namespace ControlServices.Core.Domain.Entities.Base;

public class BaseEntity : IEntity
{
    public Guid Id { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }
}
