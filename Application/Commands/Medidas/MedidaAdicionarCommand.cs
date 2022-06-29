using Application.Validation.Medidas;
using Application.ViewModel.Medidas;
using Domain.Interface.Repository;

namespace Application.Commands.Medidas
{
    public class MedidaAdicionarCommand : Command
    {
        public MedidaAdicionarViewModel medidaAdicionarViewModel { get; private set; }
        private readonly IPacienteRepository pacienteRepository;

        public MedidaAdicionarCommand(
            MedidaAdicionarViewModel medidaAdicionarViewModel,
            IPacienteRepository pacienteRepository)
        {
            this.medidaAdicionarViewModel = medidaAdicionarViewModel;
            this.pacienteRepository = pacienteRepository;
        }

        public override bool EhValido()
        {
            ValidationResult = new MedidaAdicionarValidation(pacienteRepository).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
