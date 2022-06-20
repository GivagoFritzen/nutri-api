using System;
using System.Collections.Generic;

namespace Application.ViewModel.Pacientes
{
    public class PacientePlanoAlimentarViewModel
    {
        public Guid PacienteId { get; set; }
        public List<RefeicaoViewModel> Refeicoes { get; set; }
    }
}
