﻿using API.Controllers.Base;
using Application.Interfaces;
using Application.ViewModel;
using Application.ViewModel.Medidas;
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
        public async Task<ActionResult> Update([FromBody] PacienteAtualizarViewModel pacienteViewModel)
        {
            return CustomResponse(await applicationServicePaciente.Update(pacienteViewModel));
        }

        [HttpPost("AdicionarMedida")]
        [AllowAnonymous]
        public async Task<ActionResult> AdicionarMedida([FromBody] MedidaAdicionarViewModel adicionarViewModel)
        {
            return CustomResponse(await applicationServicePaciente.AdicionarMedidas(adicionarViewModel));
        }

        [HttpPut("AtualizarMedida")]
        [AllowAnonymous]
        public async Task<ActionResult> AtualizarMedida([FromBody] MedidaAtualizarViewModel atualizarViewModel)
        {
            return CustomResponse(await applicationServicePaciente.AtualizarMedidas(atualizarViewModel));
        }

        [HttpPost("AdicionarPlanoAlimentar")]
        [AllowAnonymous]
        public async Task<ActionResult> AdicionarPlanoAlimentar([FromBody] PacientePlanoAlimentarViewModel pacienteViewModel)
        {
            return CustomResponse(await applicationServicePaciente.AdicionarPlanoAlimentar(pacienteViewModel));
        }

        [HttpPatch("AtualizarPlanoAlimentar")]
        [AllowAnonymous]
        public ActionResult AtualizarPlanoAlimentar([FromBody] PacienteAtualizarPlanoAlimentarViewModel pacienteViewModel)
        {
            return CustomResponse(applicationServicePaciente.AtualizarPlanoAlimentar(pacienteViewModel));
        }
    }
}