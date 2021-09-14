using API.Controllers.Base;
using Application.Interfaces;
using Application.ViewModel;
using Application.ViewModel.Pacientes;
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
        public async Task<IActionResult> GetAll()
        {
            return CustomResponse(await applicationServicePaciente.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return CustomResponse(await applicationServicePaciente.GetById(id));
        }

        [HttpPost]
        public ActionResult<ResponseView> Add([FromBody] PacienteAdicionarViewModel pacienteViewModel)
        {
            return applicationServicePaciente.Add(pacienteViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(Guid id)
        {
            await applicationServicePaciente.RemoveById(id);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update([FromBody] PacienteViewModel pacienteViewModel)
        {
            applicationServicePaciente.Update(pacienteViewModel);
            return Ok();
        }
    }
}