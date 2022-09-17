using Application.ViewModel.Refeicao;
using System;
using System.Collections.Generic;

namespace Application.ViewModel.Pacientes
{
    public class PacientePlanoAlimentarViewModel : BaseViewModel
    {
        public Guid PacienteId { get; set; }
        public List<RefeicaoViewModel> Refeicoes { get; set; }
    }
}
