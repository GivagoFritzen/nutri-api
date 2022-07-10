﻿using API.Attributes;
using API.Controllers.Base;
using Application.Interfaces;
using Application.ViewModel.Nutricionistas;
using Application.ViewModel.Pacientes;
using CrossCutting.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        [AuthorizeRoles(Permissoes.Nutricionista)]
        public async Task<ActionResult<NutricionistaViewModel>> GetById(Guid id)
        {
            return CustomResponse(await applicationServiceNutricionista.GetById(id));
        }

        [HttpGet("GetAll")]
        [AuthorizeRoles(Permissoes.Nutricionista)]
        public async Task<ActionResult<IEnumerable<NutricionistaViewModel>>> GetAll()
        {
            return CustomResponse(await applicationServiceNutricionista.GetAll());
        }

        [HttpGet("GetPacientes")]
        [AuthorizeRoles(Permissoes.Nutricionista)]
        public async Task<ActionResult<IEnumerable<PacienteSimplificadoViewModel>>> GetPacientes(Guid id)
        {
            return CustomResponse(await applicationServiceNutricionista.GetPacientes(id));
        }

        [HttpPost]
        [AuthorizeRoles(Permissoes.Nutricionista)]
        public async Task<IActionResult> Add([FromBody] NutricionistaAdicionarViewModel nutricionistaViewModel)
        {
            return CustomResponse(await applicationServiceNutricionista.Add(nutricionistaViewModel));
        }

        [HttpDelete("{id}")]
        [AuthorizeRoles(Permissoes.Nutricionista)]
        public async Task<IActionResult> RemoveById(Guid id)
        {
            await applicationServiceNutricionista.RemoveById(id);
            return Ok();
        }

        [HttpPut]
        [AuthorizeRoles(Permissoes.Nutricionista)]
        public ActionResult<NutricionistaAtualizarViewModel> Update([FromBody] NutricionistaAtualizarViewModel nutricionistaViewModel)
        {
            return CustomResponse(applicationServiceNutricionista.Update(nutricionistaViewModel));
        }

        [HttpPatch("VincularPaciente")]
        [AuthorizeRoles(Permissoes.Nutricionista)]
        public async Task<ActionResult<NutricionistaDesvincularOuVincularViewModel>> VincularPaciente([FromBody] NutricionistaDesvincularOuVincularViewModel nutricionistaViewModel)
        {
            return CustomResponse(await applicationServiceNutricionista.VincularPaciente(nutricionistaViewModel));
        }

        [HttpPatch("DesvincularPaciente")]
        [AuthorizeRoles(Permissoes.Nutricionista)]
        public async Task<ActionResult<NutricionistaDesvincularOuVincularViewModel>> DesvincularPaciente(string paciente)
        {
            return CustomResponse(await applicationServiceNutricionista.DesvincularPaciente(
                paciente,
                HttpContext.Request.Headers["Authorization"]));
        }
    }
}