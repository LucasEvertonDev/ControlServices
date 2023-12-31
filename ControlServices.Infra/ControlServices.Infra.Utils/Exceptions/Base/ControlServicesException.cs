﻿using System.Runtime.Serialization;

namespace ControlServices.Infra.Utils.Exceptions.Base;

[Serializable]
public class ControlServicesException : SystemException
{
    public ControlServicesException(string message) : base(message)
    {
    }

    protected ControlServicesException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
