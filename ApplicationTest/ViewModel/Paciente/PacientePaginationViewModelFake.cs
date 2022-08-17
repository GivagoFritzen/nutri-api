using Application.ViewModel.Pacientes;
using Domain.Event;
using DomainTest.Event;
using System;
using System.Collections.Generic;

namespace ApplicationTest.ViewModel.Paciente
{
    public static class PacientePaginationViewModelFake
    {
        public static PacientePaginationViewModel GetFake(Guid id)
        {
            return new PacientePaginationViewModel()
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
