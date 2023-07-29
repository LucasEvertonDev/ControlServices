using ControlServices.Infra.Utils.Exceptions.Base;
using ControlServices.Infra.Utils.Resources;
using System.Runtime.Serialization;

namespace ControlServices.Infra.Utils.Exceptions;

[Serializable]
public class BadCredentialsException : ControlServicesException
{
    public BadCredentialsException() : base(ResourceMessages.UserOrPasswordInvalid)
    {   

    }

    protected BadCredentialsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
