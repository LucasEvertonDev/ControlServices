using ControlServices.Infra.Utils.Exceptions.Base;
using System.Runtime.Serialization;

namespace ControlServices.Infra.Utils.Exceptions;

[Serializable]
public class BusinessException : ControlServicesException
{
    public List<string> ErrorsMessages { get; set; }

    public BusinessException(string message) : base(message)
    {
    }

    public BusinessException(List<string> errorsMessage) : base(string.Empty)
    {
        ErrorsMessages = errorsMessage;
    }

    protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
