using System;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Pacientes
{
    public class PacienteAtualizarViewModel : PacienteAdicionarViewModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}
