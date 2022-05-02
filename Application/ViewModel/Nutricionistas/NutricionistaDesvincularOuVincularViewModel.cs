using System;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Nutricionistas
{
    public class NutricionistaDesvincularOuVincularViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string PacienteEmail { get; set; }
    }
}
