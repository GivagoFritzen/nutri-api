using Application.ViewModel;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public ActionResult<IEnumerable<string>> GetAll()
        {
            return Ok(applicationServicePaciente.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(applicationServicePaciente.GetById(id));
        }

        [HttpPost]
        public ActionResult Add([FromBody] PacienteViewModel pacienteViewModel)
        {
            try
            {
                if (pacienteViewModel == null)
                    return NotFound();

                applicationServicePaciente.Add(pacienteViewModel);
                return Ok("Cliente Cadastrado com Sucesso");
            }
            catch (Exception)
            {
                throw;
            };
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
        public ActionResult Update(PacienteViewModel pacienteViewModel)
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