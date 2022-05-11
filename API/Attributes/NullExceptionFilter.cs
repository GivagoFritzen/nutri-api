using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Attributes
{
    public class NullExceptionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}
