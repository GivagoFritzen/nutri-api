using System;
using System.Collections.Generic;

namespace Application.ViewModel.Pacientes
{
    public class RefeicaoViewModel
    {
        public DateTime Horario { get; set; }
        public string Descricao { get; set; }
        public List<AlimentoViewModel> Alimentos { get; set; }
    }
}
