using System;

namespace Application.ViewModel.Pacientes
{
    public class PacienteSimplificadoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
