using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Nutricionistas
{
    public class NutricionistaAdicionarViewModel : NutricionistaViewModel
    {
        [Required]
        public string Senha { get; set; }
    }
}
