using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Nutricionistas
{
    public class NutricionistaAtualizarViewModel : NutricionistaViewModel
    {
        [Required]
        public Guid Id { get; set; }
        public string AntigaSenha { get; set; }

        [DefaultValue("")]
        public string NovaSenha { get; set; }
    }
}
