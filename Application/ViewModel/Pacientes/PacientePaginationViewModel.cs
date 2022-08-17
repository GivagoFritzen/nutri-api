using Domain.Event;
using System.Collections.Generic;

namespace Application.ViewModel.Pacientes
{
    public class PacientePaginationViewModel
    {
        public List<PacienteEvent> Data { get; set; }
        public int Total { get; set; }
    }
}
