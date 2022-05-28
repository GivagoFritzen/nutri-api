using API.Attributes;
using API.Controllers.Base;
using Application.Interfaces;
using Application.ViewModel;
using Application.ViewModel.Nutricionistas;
using CrossCutting.Authentication;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            return CustomResponse(await applicationServiceNutricionista.GetById(id));
        }

        [HttpGet("GetAll")]
        [AuthorizeRoles(Permissoes.Nutricionista)]
        public async Task<IActionResult> GetAll()
        {
            return CustomResponse(await applicationServiceNutricionista.GetAll());
        }

        [HttpGet("GetPacientes")]
        [AuthorizeRoles(Permissoes.Nutricionista)]
        public async Task<IActionResult> GetPacientes(Guid id)
        {
            return CustomResponse(await applicationServiceNutricionista.GetPacientes(id));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<ResponseView>> Add([FromBody] NutricionistaAdicionarViewModel nutricionistaViewModel)
        {
            return CustomResponse(await applicationServiceNutricionista.Add(nutricionistaViewModel));
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> Remove(Guid id)
        {
            await applicationServiceNutricionista.RemoveById(id);
            return Ok();
        }

        [HttpPut]
        [AllowAnonymous]
        public ActionResult Update([FromBody] NutricionistaAtualizarViewModel nutricionistaViewModel)
        {
            return CustomResponse(applicationServiceNutricionista.Update(nutricionistaViewModel));
        }

        [HttpPatch("VincularPaciente")]
        [AllowAnonymous]
        public async Task<ActionResult<ResponseView>> VincularPaciente([FromBody] NutricionistaDesvincularOuVincularViewModel nutricionistaViewModel)
        {
            return CustomResponse(await applicationServiceNutricionista.VincularPaciente(nutricionistaViewModel));
        }

        [HttpPatch("DesvincularPaciente")]
        [AuthorizeRoles(Permissoes.Nutricionista)]
        public async Task<ActionResult<ResponseView>> DesvincularPaciente(string paciente)
        {
            return CustomResponse(await applicationServiceNutricionista.DesvincularPaciente(
                paciente,
                HttpContext.Request.Headers["Authorization"]));
        }
    }
}