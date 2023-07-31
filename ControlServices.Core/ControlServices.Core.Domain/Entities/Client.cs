using ControlServices.Core.Domain.Entities.Base;

namespace ControlServices.Core.Domain.Entities;

public class Client : BaseEntity
{
    public string Cpf { get; set; }
    public string Name { get; set; }
    public DateTime? BirthDate { get; set; }
    public string PhoneNumber { get; set; }
}
