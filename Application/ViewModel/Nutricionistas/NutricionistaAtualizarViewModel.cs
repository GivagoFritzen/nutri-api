using System;
using System.ComponentModel;

namespace Application.ViewModel.Nutricionistas
{
    public class NutricionistaAtualizarViewModel : NutricionistaViewModel
    {
        public Guid Id { get; set; }
        public string AntigaSenha { get; set; }

        [DefaultValue("")]
        public string NovaSenha { get; set; }
    }
}
