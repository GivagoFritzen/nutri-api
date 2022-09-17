using Application.ViewModel.Refeicao;
using System;
using System.Collections.Generic;

namespace Application.ViewModel.PlanosAlimentares
{
    public class PlanoAlimentarViewModel
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public List<RefeicaoViewModel> Refeicoes { get; set; }
    }
}
