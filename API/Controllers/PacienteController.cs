using Application.DTO;
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
        public ActionResult Add([FromBody] PacienteDTO pacienteDTO)
        {
            try
            {
                if (pacienteDTO == null)
                    return NotFound();

                applicationServicePaciente.Add(pacienteDTO);
                return Ok("Cliente Cadastrado com Sucesso");
            }
            catch (Exception)
            {
                throw;
            };
        }

        [HttpDelete]
        public ActionResult Remove([FromBody] PacienteDTO pacienteDTO)
        {
            try
            {
                if (pacienteDTO == null)
                    return NotFound();

                applicationServicePaciente.Add(pacienteDTO);
                return Ok("Cliente Cadastrado com Sucesso");
            }
            catch (Exception)
            {
                throw;
            };
        }

        [HttpPut]
        public ActionResult Update(PacienteDTO pacienteDTO)
        {
            try
            {
                if (pacienteDTO == null)
                    return NotFound();

                applicationServicePaciente.Update(pacienteDTO);
                return Ok("Cliente Cadastrado com Sucesso");
            }
            catch (Exception)
            {
                throw;
            };
        }
    }
}
