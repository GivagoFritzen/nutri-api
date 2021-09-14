using Application.Commands;
using Core.Interfaces.Services;
using CrossCutting.Message.Validation;
using FluentValidation;

namespace Application.Validation
{
    public static class GenericValidators
    {
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
    }
}
