using ControlServices.Core.Models.Models.Base;

namespace ControlServices.Core.Models.Requests;

public class RequestDTO<TRequest> where TRequest : BaseModel
{
    public RequestDTO()
    {
        Model = Activator.CreateInstance<TRequest>();
    }

    public TRequest Model { get; set; }
}
