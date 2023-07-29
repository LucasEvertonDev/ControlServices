using ControlServices.Core.Models.Models.Errors;
using ControlServices.Core.Models.Responses;
using ControlServices.Infra.Utils.Exceptions;
using ControlServices.Infra.Utils.Exceptions.Base;
using ControlServices.Infra.Utils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ControlServices.API.Infrastructure.Filter;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ControlServicesException)
        {
            HandleCustomExceptions(context);
        }
        else
        {
            HandleUnknownError(context);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    private static void HandleCustomExceptions(ExceptionContext context)
    {
        if (context.Exception is BusinessException)
        {
            var validationException = context.Exception as BusinessException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new ObjectResult
                (
                        new ResponseDTO<ErrorsModel>()
                        {
                            Sucess = false,
                            Content = new ErrorsModel(validationException.ErrorsMessages.ToArray())
                        }
                );
        }
        else
        {
            var exception = context.Exception as ControlServicesException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new ObjectResult
                (
                        new ResponseDTO<ErrorsModel>()
                        {
                            Sucess = false,
                            Content = new ErrorsModel(exception.Message)
                        }
                );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    private static void HandleUnknownError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult
           (
                   new ResponseDTO<ErrorsModel>()
                   {
                       Sucess = false,
                       Content = new ErrorsModel(ResourceMessages.Unknownerror)
                   }
           );
    }
}
