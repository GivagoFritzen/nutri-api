using Application.Commands.Login;
using Application.Interfaces;
using Application.ViewModel;
using Application.ViewModel.Login;
using CrossCutting.Message.Exceptions;
using Domain.Event;
using Domain.Interface.Repository;
using Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApplicationServiceLogin : IApplicationServiceLogin
    {
        private readonly ITokenService tokenService;
        private readonly INutricionistaRepository nutricionistaRepository;
        private readonly ISecurityService securityService;

        public ApplicationServiceLogin(ITokenService tokenService,
            INutricionistaRepository nutricionistaService,
            ISecurityService securityRepository)
        {
            this.tokenService = tokenService;
            this.nutricionistaRepository = nutricionistaService;
            this.securityService = securityRepository;
        }

        public async Task<ResponseView> Login(LoginNutricionistaViewModel loginViewModel)
        {
            var command = new LoginNutricionistaCommand(loginViewModel);
            if (!command.EhValido())
                return new ResponseView(command.ValidationResult);

            NutricionistaEvent nutricionista = null;
            try
            {
                nutricionista = await nutricionistaRepository.GetByEmail(loginViewModel.Email);

                if (!securityService.VerifyPassword(loginViewModel.Senha, nutricionista.Senha))
                    ExceptionUsuarioOuSenhaInvalido();
            }
            catch
            {
                ExceptionUsuarioOuSenhaInvalido();
            }

            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, nutricionista.Nome),
                new Claim(ClaimTypes.Email, loginViewModel.Email),
                new Claim(ClaimTypes.PrimarySid, nutricionista.Id.ToString()),
                new Claim(ClaimTypes.Role, loginViewModel.Permissao.ToString())
            };

            var tokenEntity = tokenService.GetLoginToken(claims);

            return new ResponseView(new LoginTokenViewModel()
            {
                Token = tokenEntity.Token,
                RefreshToken = tokenEntity.RefreshToken
            });
        }

        public ResponseView Refresh(string token, string refreshToken)
        {
            //Verifica se o refreshToken é valido (Lista)

            var principal = tokenService.GetPrincipalFromToken(token);
            var tokenEntity = tokenService.GetLoginToken(principal.Claims);

            // Deletar Refresh Token
            // Salvar novo Refresh Token

            return new ResponseView(new LoginTokenViewModel()
            {
                Token = tokenEntity.Token,
                RefreshToken = tokenEntity.RefreshToken
            });
        }

        private void ExceptionUsuarioOuSenhaInvalido()
        {
            throw new InvalidOperationException($"{ExceptionsMessages.UsuarioOuSenhaInvalido}");
        }
    }
}
