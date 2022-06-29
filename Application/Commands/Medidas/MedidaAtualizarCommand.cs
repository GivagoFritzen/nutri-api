using Application.Validation.Medidas;
using Application.ViewModel.Medidas;
using Domain.Interface.Repository;

namespace Application.Commands.Medidas
{
    public class MedidaAtualizarCommand : Command
    {
        public MedidaAtualizarViewModel medidaAtualizarViewModel { get; private set; }
        private readonly IMedidaRepository medidaRepository;
        private readonly IPacienteRepository pacienteRepository;

        public MedidaAtualizarCommand(
            MedidaAtualizarViewModel medidaAtualizarViewModel,
            IMedidaRepository medidaRepository,
            IPacienteRepository pacienteRepository)
        {
            this.medidaAtualizarViewModel = medidaAtualizarViewModel;
            this.medidaRepository = medidaRepository;
            this.pacienteRepository = pacienteRepository;
        }

        public override bool EhValido()
        {
            ValidationResult = new MedidaAtualizarValidation(medidaRepository, pacienteRepository).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
