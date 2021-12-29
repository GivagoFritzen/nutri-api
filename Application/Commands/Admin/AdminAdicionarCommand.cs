using Application.Validation.Admin;
using Application.ViewModel.Admin;

namespace Application.Commands.Admin
{
    public class AdminAdicionarCommand : Command
    {
        public AdminAdicionarViewModel adminAdicionarViewModel { get; private set; }

        public AdminAdicionarCommand(AdminAdicionarViewModel adminAdicionarViewModel)
        {
            this.adminAdicionarViewModel = adminAdicionarViewModel;
        }

        public override bool EhValido()
        {
            ValidationResult = new AdminAdicionarValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
