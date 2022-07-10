using CrossCutting.Authentication;

namespace Application.ViewModel.Login
{
    public class LoginNutricionistaViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public Permissoes Permissao = Permissoes.Nutricionista;
    }
}
