using Application.Commands.Login;
using Application.Interfaces;
using Application.Mapper;
using Application.ViewModel;
using Application.ViewModel.Login;
using CrossCutting.Message.Exceptions;
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
        private readonly ISecurityService securityService;
        private readonly ITokenRepository tokenRepository;
        private readonly INutricionistaRepository nutricionistaRepository;

        public ApplicationServiceLogin(ITokenService tokenService,
            ISecurityService securityService,
            ITokenRepository tokenRepository,
            INutricionistaRepository nutricionistaRepository)
        {
            this.tokenService = tokenService;
            this.securityService = securityService;
            this.nutricionistaRepository = nutricionistaRepository;
            this.tokenRepository = tokenRepository;
        }

        public async Task<BaseViewModel> Login(LoginNutricionistaViewModel loginViewModel)
        {
            var command = new LoginNutricionistaCommand(loginViewModel);
            if (!command.EhValido())
                return new ErrorViewModel(command.ValidationResult);

            var nutricionista = await nutricionistaRepository.GetByEmail(loginViewModel.Email);
            if (!securityService.VerifyPassword(loginViewModel.Senha, nutricionista.Senha))
                throw new UnauthorizedAccessException($"{ExceptionsMessages.UsuarioOuSenhaInvalido}");

            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, nutricionista.Nome),
                new Claim(ClaimTypes.Email, loginViewModel.Email),
                new Claim(ClaimTypes.PrimarySid, nutricionista.Id.ToString()),
                new Claim(ClaimTypes.Role, loginViewModel.Permissao.ToString())
            };

            var tokenDTO = tokenService.GetLoginToken(claims);
            tokenRepository.AddRefreshToken(tokenDTO.ToEvent());
            return tokenDTO.ToViewModel();
        }

        public BaseViewModel Refresh(LoginTokenViewModel loginTokenViewModel)
        {
            var command = new RefreshTokenCommand(loginTokenViewModel, tokenRepository);
            if (!command.EhValido())
                return new ErrorViewModel(command.ValidationResult);

            var principal = tokenService.GetPrincipalFromToken(loginTokenViewModel.Token);
            var tokenDTO = tokenService.GetLoginToken(principal.Claims);

            tokenRepository.UpdateRefreshToken(tokenDTO.ToEvent(), loginTokenViewModel.RefreshToken);
            return tokenDTO.ToViewModel();
        }
    }
}
