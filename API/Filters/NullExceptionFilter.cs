using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters
{
    public class NullExceptionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}
