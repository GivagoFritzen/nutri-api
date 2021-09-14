using System;
using System.Collections.Generic;

namespace Application.ViewModel.Medidas
{
    public class MedidaViewModel
    {
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public float PesoAtual { get; set; }
        public float PesoIdeal { get; set; }
        public float Altura { get; set; }
        public List<CircunferenciasViewModel> Circunferencias { get; set; }
    }
}
