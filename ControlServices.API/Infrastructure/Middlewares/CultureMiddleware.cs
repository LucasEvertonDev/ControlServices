using ControlServices.Infra.Utils.Resources;
using System.Globalization;

namespace ControlServices.API.Infrastructure.Middlewares;
public class CultureMiddleware
{
    private readonly RequestDelegate _next;

    private readonly IList<string> _idiomasSuportados = new List<string>
    {
        "pt",
        "en"
    };

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

            if (_idiomasSuportados.Any(c => c.Equals(linguagem)))
            {
                cultura = new CultureInfo(linguagem);
            }
        }
        ResourceMessages.Culture = cultura;

        CultureInfo.CurrentCulture = cultura;
        CultureInfo.CurrentUICulture = cultura;

        await _next(context);
    }
}
