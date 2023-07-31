using Microsoft.AspNetCore.Mvc.Filters;

namespace ControlServices.API.Infrastructure.Attributes
{
    public class DecodeUrlActionFilterParameter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
    }
}
