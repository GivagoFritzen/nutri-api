using Domain.DTO.Paciente;
using Domain.Event;
using DomainTest.Event;
using System;
using System.Collections.Generic;

namespace DomainTest.DTO
{
    public static class PacientePaginationDTOFake
    {
        public static PacientePaginationDTO GetFake(Guid id)
        {
            return new PacientePaginationDTO()
            {
                Data = new List<PacienteEvent>()
                {
                    PacienteEventFake.GetPacienteEventUpdateFake(id)
                },
                Total = 1
            };
        }
    }
}
