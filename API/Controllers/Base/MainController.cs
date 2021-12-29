using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers.Base
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ActionResult CustomResponse(object result)
        {
            return Ok(result);
        }

        protected ActionResult CustomResponse(ResponseView result = null)
        {
            if (result.Errors == null || !result.Errors.Any())
                return Ok(result);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", result.Errors }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            if (erros.Any())
                return CustomResponse(new ResponseView(erros.Select(e => e.ErrorMessage).ToArray()));

            return CustomResponse();
        }
    }
}
