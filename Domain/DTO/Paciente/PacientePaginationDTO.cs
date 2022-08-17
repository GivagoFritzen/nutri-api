using Domain.Event;
using System.Collections.Generic;

namespace Domain.DTO.Paciente
{
    public class PacientePaginationDTO
    {
        public List<PacienteEvent> Data { get; set; }
        public int Total { get; set; }
    }
}
