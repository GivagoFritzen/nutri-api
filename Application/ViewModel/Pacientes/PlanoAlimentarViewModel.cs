using System;
using System.Collections.Generic;

namespace Application.ViewModel.Pacientes
{
    public class PlanoAlimentarViewModel
    {
        public DateTime Data { get; set; }
        public List<RefeicaoViewModel> Refeicoes { get; set; }
    }
}
