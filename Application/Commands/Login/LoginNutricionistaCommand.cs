using Application.Validation.Login;
using Application.ViewModel.Login;

namespace Application.Commands.Login
{
    public class LoginNutricionistaCommand : Command
    {
        public LoginNutricionistaViewModel loginNutricionistaViewModel { get; private set; }

        public LoginNutricionistaCommand(LoginNutricionistaViewModel loginNutricionistaViewModel)
        {
            this.loginNutricionistaViewModel = loginNutricionistaViewModel;
        }

        public override bool EhValido()
        {
            ValidationResult = new LoginNutricionistaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
