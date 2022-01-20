using API.Controllers.Base;
using Application.Interfaces;
using Application.ViewModel;
using Application.ViewModel.Nutricionistas;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutricionistaController : MainController
    {
        private readonly IApplicationServiceNutricionista applicationServiceNutricionista;

        public NutricionistaController(IApplicationServiceNutricionista applicationServiceNutricionista)
        {
            this.applicationServiceNutricionista = applicationServiceNutricionista;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return CustomResponse(await applicationServiceNutricionista.GetById(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return CustomResponse(await applicationServiceNutricionista.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<ResponseView>> Add([FromBody] NutricionistaAdicionarViewModel nutricionistaViewModel)
        {
            return CustomResponse(await applicationServiceNutricionista.Add(nutricionistaViewModel));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(Guid id)
        {
            await applicationServiceNutricionista.RemoveById(id);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update([FromBody] NutricionistaAtualizarViewModel nutricionistaViewModel)
        {
            return CustomResponse(applicationServiceNutricionista.Update(nutricionistaViewModel));
        }
    }
}