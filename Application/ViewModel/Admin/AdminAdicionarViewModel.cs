using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Admin
{
    public class AdminAdicionarViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
