using ControlServices.Core.Models.Models.Clients.Base;
using System.ComponentModel;

namespace ControlServices.Core.Models.Models.Clients;

public class CreateClientsModel : ClientModel
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string Id { get => base.Id; }
}
