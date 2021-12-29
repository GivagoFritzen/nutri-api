using Application.Commands;
using Core.Interfaces.Services;
using CrossCutting.Message.Validation;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Validation
{
    public static class GenericValidators
    {
        #region Senha
        public static IRuleBuilderOptions<T, Element> ValidarNovaSenha<T, Element>(this IRuleBuilder<T, Element> ruleBuilder, ISecurityService securityService)
            where Element : UserCommand
        {
            return ruleBuilder.Must(c => ValidarNovaSenha(securityService, c.AntigaSenha, c.NovaSenha))
                    .WithMessage(GenericValidationMessages.SenhaNaoPodeSerIgual);
        }

        private static bool ValidarNovaSenha(ISecurityService securityService, string antigaSenha, string novaSenha)
        {
            if (string.IsNullOrEmpty(novaSenha))
                return true;

            return !securityService.ComparePassword(antigaSenha, novaSenha);
        }
        #endregion

        #region Email
        private const int EmailMaxLength = 254;
        private const int EmailMinLength = 5;

        public static IRuleBuilderOptions<T, string> ValidarEmail<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .MinimumLength(EmailMinLength)
                .WithMessage(string.Format(GenericValidationMessages.CaracteresMinimo, "Email", EmailMinLength))
                .MaximumLength(EmailMaxLength)
                .WithMessage(string.Format(GenericValidationMessages.CaracteresMaximo, "Email", EmailMaxLength))
                .Must(email => Validar(email))
                .WithMessage(GenericValidationMessages.RequisitosEmail);
        }

        public static bool Validar(string email)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(email);
        }
        #endregion
    }
}
