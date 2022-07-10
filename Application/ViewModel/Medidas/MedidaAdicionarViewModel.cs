using System;

namespace Application.ViewModel.Medidas
{
    public class MedidaAdicionarViewModel : BaseViewModel
    {
        public Guid PacienteId { get; set; }
        public MedidaViewModel Medida { get; set; }
    }
}
