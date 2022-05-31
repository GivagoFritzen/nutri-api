using Application.Validation.Login;
using Application.ViewModel.Login;
using Domain.Interface.Repository;

namespace Application.Commands.Login
{
    public class RefreshTokenCommand : Command
    {
        public ITokenRepository tokenRepository { get; private set; }
        public LoginTokenViewModel loginTokenViewModel { get; private set; }

        public RefreshTokenCommand(LoginTokenViewModel loginTokenViewModel, ITokenRepository tokenRepository)
        {
            this.loginTokenViewModel = loginTokenViewModel;
            this.tokenRepository = tokenRepository;
        }

        public override bool EhValido()
        {
            ValidationResult = new RefreshTokenValidation(tokenRepository).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
