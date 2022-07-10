using API.Attributes;
using API.Controllers.Base;
using Application.Interfaces;
using Application.ViewModel.Medidas;
using Application.ViewModel.Pacientes;
using CrossCutting.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : MainController
    {
        private readonly IApplicationServicePaciente applicationServicePaciente;

        public PacienteController(IApplicationServicePaciente applicationServicePaciente)
        {
            this.applicationServicePaciente = applicationServicePaciente;
        }

        [HttpGet("{id}")]
        [AuthorizeRoles(Permissoes.Nutricionista)]
        public async Task<ActionResult<PacienteViewModel>> GetById(Guid id)
        {
            return CustomResponse(await applicationServicePaciente.GetById(id));
        }

        [HttpPost]
        [AuthorizeRoles(Permissoes.Nutricionista)]
        public async Task<IActionResult> Add([FromBody] PacienteAdicionarViewModel pacienteViewModel)
        {
            return CustomResponse(await applicationServicePaciente.Add(pacienteViewModel));
        }

        [HttpDelete("{id}")]
        [AuthorizeRoles(Permissoes.Nutricionista)]
        public async Task<IActionResult> Remove(Guid id)
        {
            await applicationServicePaciente.RemoveById(id);
            return Ok();
        }

        [HttpPut]
        [AuthorizeRoles(Permissoes.Nutricionista)]
        public async Task<ActionResult<PacienteAtualizarViewModel>> Update([FromBody] PacienteAtualizarViewModel pacienteViewModel)
        {
            return CustomResponse(await applicationServicePaciente.Update(pacienteViewModel));
        }

        [HttpPost("AdicionarMedida")]
        [AuthorizeRoles(Permissoes.Nutricionista)]
        public async Task<ActionResult<MedidaAdicionarViewModel>> AdicionarMedida([FromBody] MedidaAdicionarViewModel adicionarViewModel)
        {
            return CustomResponse(await applicationServicePaciente.AdicionarMedidas(adicionarViewModel));
        }

        [HttpPut("AtualizarMedida")]
        [AuthorizeRoles(Permissoes.Nutricionista)]
        public async Task<ActionResult<MedidaAtualizarViewModel>> AtualizarMedida([FromBody] MedidaAtualizarViewModel atualizarViewModel)
        {
            return CustomResponse(await applicationServicePaciente.AtualizarMedidas(atualizarViewModel));
        }

        [HttpPost("AdicionarPlanoAlimentar")]
        [AuthorizeRoles(Permissoes.Nutricionista)]
        public async Task<ActionResult<PacientePlanoAlimentarViewModel>> AdicionarPlanoAlimentar([FromBody] PacientePlanoAlimentarViewModel pacienteViewModel)
        {
            return CustomResponse(await applicationServicePaciente.AdicionarPlanoAlimentar(pacienteViewModel));
        }

        [HttpPatch("AtualizarPlanoAlimentar")]
        [AuthorizeRoles(Permissoes.Nutricionista)]
        public ActionResult<PacienteAtualizarPlanoAlimentarViewModel> AtualizarPlanoAlimentar([FromBody] PacienteAtualizarPlanoAlimentarViewModel pacienteViewModel)
        {
            return CustomResponse(applicationServicePaciente.AtualizarPlanoAlimentar(pacienteViewModel));
        }
    }
}