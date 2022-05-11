using API.Controllers.Base;
using Application.Interfaces;
using Application.ViewModel;
using Application.ViewModel.Pacientes;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            return CustomResponse(await applicationServicePaciente.GetAll());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            return CustomResponse(await applicationServicePaciente.GetById(id));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<ResponseView>> Add([FromBody] PacienteAdicionarViewModel pacienteViewModel)
        {
            return CustomResponse(await applicationServicePaciente.Add(pacienteViewModel));
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> Remove(Guid id)
        {
            await applicationServicePaciente.RemoveById(id);
            return Ok();
        }

        [HttpPut]
        [AllowAnonymous]
        public ActionResult Update([FromBody] PacienteAtualizarViewModel pacienteViewModel)
        {
            return CustomResponse(applicationServicePaciente.Update(pacienteViewModel));
        }
    }
}