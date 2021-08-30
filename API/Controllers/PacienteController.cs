using Application.Interfaces;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IApplicationServicePaciente applicationServicePaciente;

        public PacienteController(IApplicationServicePaciente applicationServicePaciente)
        {
            this.applicationServicePaciente = applicationServicePaciente;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await applicationServicePaciente.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await applicationServicePaciente.GetById(id));
        }

        [HttpPost]
        public ActionResult<ResponseView> Add([FromBody] PacienteViewModel pacienteViewModel)
        {
            return applicationServicePaciente.Add(pacienteViewModel);
        }

        [HttpDelete]
        public ActionResult Remove([FromBody] PacienteViewModel pacienteViewModel)
        {
            try
            {
                if (pacienteViewModel == null)
                    return NotFound();

                applicationServicePaciente.Remove(pacienteViewModel);
                return Ok("Cliente Cadastrado com Sucesso");
            }
            catch (Exception)
            {
                throw;
            };
        }

        [HttpPut]
        public ActionResult Update([FromBody] PacienteViewModel pacienteViewModel)
        {
            try
            {
                if (pacienteViewModel == null)
                    return NotFound();

                applicationServicePaciente.Update(pacienteViewModel);
                return Ok("Cliente Cadastrado com Sucesso");
            }
            catch (Exception)
            {
                throw;
            };
        }
    }
}