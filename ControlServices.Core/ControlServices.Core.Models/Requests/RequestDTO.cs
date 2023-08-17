using ControlServices.Core.Models.Models.Base;
using ControlServices.Core.Models.Models.User;
using System.ComponentModel;

namespace ControlServices.Core.Models.Requests;

public class RequestDTO<TRequest> where TRequest : BaseModel
{
    public RequestDTO()
    {
        Body = Activator.CreateInstance<TRequest>();
    }

    public TRequest Body { get; set; }

    //[DefaultValue("Teste")]
    //public string Teste { get; set; }
}
