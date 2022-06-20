using Application.ViewModel.Pacientes;
using ApplicationTest.ViewModel.PlanoAlimentar;
using System;

namespace ApplicationTest.ViewModel.Paciente
{
    public static class PacienteAtualizarPlanoAlimentarViewModelFake
    {
        public static PacienteAtualizarPlanoAlimentarViewModel GetFake()
        {
            return new PacienteAtualizarPlanoAlimentarViewModel()
            {
                PlanoAlimentarId = Guid.NewGuid(),
                PlanoAlimentar = PlanoAlimentarViewModelFake.GetFake()
            };
        }

    }
}
