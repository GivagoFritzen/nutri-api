using Microsoft.AspNetCore.Mvc;
using Nutri_Api.Models;
using Nutri_Api.Service;
using System.Collections.Generic;

namespace Nutri_Api.Controllers
{
    public class PacienteController : Controller
    {
        private PacienteService pacienteService;

        [HttpGet]
        public List<Paciente> BuscarPacientes()
        {
            return pacienteService.BuscarPacientes();
        }
    }
}
