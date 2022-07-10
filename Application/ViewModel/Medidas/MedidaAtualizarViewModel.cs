using System;

namespace Application.ViewModel.Medidas
{
    public class MedidaAtualizarViewModel : BaseViewModel
    {
        public Guid PacienteId { get; set; }
        public Guid MedidaId { get; set; }
        public MedidaViewModel Medida { get; set; }
    }
}
