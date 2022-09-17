using Application.ViewModel.Pacientes;
using System;
using System.Collections.Generic;

namespace Application.ViewModel.Refeicao
{
    public class RefeicaoViewModel
    {
        public DateTime Horario { get; set; }
        public string Descricao { get; set; }
        public List<AlimentoViewModel> Alimentos { get; set; }
    }
}
