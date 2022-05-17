using Application.Commands.Login;
using Application.Interfaces;
using Application.ViewModel;
using Application.ViewModel.Login;
using Core.Interfaces.Services;
using CrossCutting.Message.Exceptions;
using Domain.Event;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApplicationServiceLogin : IApplicationServiceLogin
    {
        private readonly ITokenService tokenService;
        private readonly INutricionistaService nutricionistaService;
        private readonly ISecurityService securityService;

        public ApplicationServiceLogin(ITokenService tokenService,
            INutricionistaService nutricionistaService,
            ISecurityService securityService)
        {
            this.tokenService = tokenService;
            this.nutricionistaService = nutricionistaService;
            this.securityService = securityService;
        }

        public async Task<ResponseView> Login(LoginNutricionistaViewModel loginViewModel)
        {
            var command = new LoginNutricionistaCommand(loginViewModel);
            if (!command.EhValido())
                return new ResponseView(command.ValidationResult);

            NutricionistaEvent nutricionista = null;
            try
            {
                nutricionista = await nutricionistaService.GetByEmail(loginViewModel.Email);

                if (!securityService.VerifyPassword(loginViewModel.Senha, nutricionista.Senha))
                    ExceptionUsuarioOuSenhaInvalido();
            }
            catch
            {
                ExceptionUsuarioOuSenhaInvalido();
            }

            return new ResponseView(tokenService.GenerateToken(
                nutricionista.Nome,
                loginViewModel.Email,
                nutricionista.Id,
                loginViewModel.Permissao
            ));
        }

        private void ExceptionUsuarioOuSenhaInvalido()
        {
            throw new InvalidOperationException($"{ExceptionsMessages.UsuarioOuSenhaInvalido}");
        }
    }
}
