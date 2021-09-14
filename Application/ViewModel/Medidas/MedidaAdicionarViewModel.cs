using System;

namespace Application.ViewModel.Medidas
{
    public class MedidaAdicionarViewModel
    {
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public float PesoAtual { get; set; }
        public float PesoIdeal { get; set; }
        public float Altura { get; set; }
        public CircunferenciasViewModel Circunferencias { get; set; }
    }
}
