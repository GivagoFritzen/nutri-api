using Application.ViewModel.PlanosAlimentares;
using System;

namespace Application.ViewModel.Pacientes
{
    public class PacienteAtualizarPlanoAlimentarViewModel : BaseViewModel
    {
        public Guid PlanoAlimentarId { get; set; }
        public PlanoAlimentarViewModel PlanoAlimentar { get; set; }
    }
}
