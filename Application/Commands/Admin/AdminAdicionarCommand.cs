using Application.Validation.Admin;
using Application.ViewModel.Admin;
using Services;

namespace Application.Commands.Admin
{
    public class AdminAdicionarCommand : Command
    {
        public AdminAdicionarViewModel adminAdicionarViewModel { get; private set; }
        private readonly IUserService userService;

        public AdminAdicionarCommand(AdminAdicionarViewModel adminAdicionarViewModel, IUserService userService)
        {
            this.adminAdicionarViewModel = adminAdicionarViewModel;
            this.userService = userService;
        }

        public override bool EhValido()
        {
            ValidationResult = new AdminAdicionarValidation(userService).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
