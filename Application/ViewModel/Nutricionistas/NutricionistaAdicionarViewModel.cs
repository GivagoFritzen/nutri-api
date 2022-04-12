using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Nutricionistas
{
    public class NutricionistaAdicionarViewModel
    {
        [Required]
        public string Senha { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        [Required]
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public bool Sexo { get; set; }
    }
}
