using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers.Base
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ActionResult CustomResponse(object result)
        {
            if (result is ErrorViewModel)
                return CustomResponse(result as ErrorViewModel);
            else
                return Ok(result);
        }

        protected ActionResult CustomResponse(ErrorViewModel result)
        {
            if (result.Errors == null || !result.Errors.Any())
                return Ok(result);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", result.Errors }
            }));
        }
    }
}
