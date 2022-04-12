using System;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Nutricionistas
{
    public class NutricionistaVincularViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string PacienteEmail { get; set; }
    }
}
