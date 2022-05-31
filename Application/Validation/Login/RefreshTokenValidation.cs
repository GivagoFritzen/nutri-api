using Application.Commands.Login;
using CrossCutting.Message.Exceptions;
using Domain.Interface.Repository;
using FluentValidation;

namespace Application.Validation.Login
{
    public class RefreshTokenValidation : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenValidation(ITokenRepository tokenRepository)
        {
            RuleFor(c => c)
                .MustAsync(async (x, cancellation) => await tokenRepository.VerificarRefreshToken(x.loginTokenViewModel.RefreshToken))
                .WithMessage(ExceptionsMessages.RefreshTokenInvalido);
        }
    }
}
