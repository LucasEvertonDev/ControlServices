using ControlServices.Core.Models.Enuns;
using ControlServices.Infra.Utils.Resources;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.OpenApi.Extensions;
using System.Globalization;

namespace ControlServices.API.Infrastructure.Middlewares;
public class CultureMiddleware
{
    private readonly RequestDelegate _next;

    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var cultura = new CultureInfo("pt");

        if (context.Request.Headers.ContainsKey("Accept-Language"))
        {
            var linguagem = context.Request.Headers["Accept-Language"].ToString();

            if (Culture.Ingles.GetDisplayName() == linguagem)
            {
                cultura = new CultureInfo("en");
            }
            else if (Culture.Portugues.GetDisplayName() == linguagem)
            {
                cultura = new CultureInfo("pt");
            }
        }

        ResourceMessages.Culture = cultura;
        CultureInfo.CurrentCulture = cultura;
        CultureInfo.CurrentUICulture = cultura;

        await _next(context);
    }
}
