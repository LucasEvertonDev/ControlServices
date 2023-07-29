using ControlServices.Core.Models.Models.Base;

namespace ControlServices.Core.Models.Requests;

public class RequestDTO<TRequest> where TRequest : BaseModel
{
    public RequestDTO()
    {
        Body = Activator.CreateInstance<TRequest>();
    }

    public TRequest Body { get; set; }
}
