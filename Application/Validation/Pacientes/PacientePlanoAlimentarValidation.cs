using Application.Commands.Pacientes;
using Application.ViewModel.Pacientes;
using Application.ViewModel.Refeicao;
using CrossCutting.Message.Validation;
using Domain.Interface.Repository;
using FluentValidation;

namespace Application.Validation.Pacientes
{
    public class PacientePlanoAlimentarValidation : AbstractValidator<PacientePlanoAlimentarCommand>
    {
        public PacientePlanoAlimentarValidation(IPacienteRepository pacienteRepository)
        {
            RuleFor(c => c.pacienteViewModel.Refeicoes)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Refeicao"))
                .ChildRules(refeicoes => refeicoes.RuleForEach(r => r)
                .SetValidator(new RefeicaoValidator())
                .ChildRules(alimentos => alimentos.RuleForEach(alimento => alimento.Alimentos)
                .SetValidator(new AlimentoValidator())));

            RuleFor(c => c)
                .MustAsync(async (x, cancellation) => await pacienteRepository.GetById(
                    x.pacienteViewModel.PacienteId
                ) is not null)
                .WithMessage(string.Format(GenericValidationMessages.NaoEncontrado, "Usuário"));
        }
    }

    public class RefeicaoValidator : AbstractValidator<RefeicaoViewModel>
    {
        public RefeicaoValidator()
        {
            RuleFor(x => x)
                .ChildRules(refeicao => refeicao.RuleForEach(d => d.Descricao))
                .Must(x => !string.IsNullOrEmpty(x.Descricao))
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Descricao"))
                .ChildRules(refeicao => refeicao.RuleFor(r => r.Alimentos)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Alimentos")));
        }
    }

    public class AlimentoValidator : AbstractValidator<AlimentoViewModel>
    {
        public AlimentoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage(string.Format(GenericValidationMessages.CampoNaoPodeSerVazio, "Nome"));

            RuleFor(x => x.Quantidade)
                .GreaterThan(0)
                .WithMessage(string.Format(GenericValidationMessages.ValorMinimo, "0"));
        }
    }
}
