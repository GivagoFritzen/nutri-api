using Nutri_Api.Models;
using System.Collections.Generic;

namespace Nutri_Api.Service
{
    public class PacienteService
    {
        public List<Paciente> BuscarPacientes()
        {
            var pacientes = new List<Paciente>();
            pacientes.Add(new Paciente("Givago"));

            return pacientes;
        }
    }
}
