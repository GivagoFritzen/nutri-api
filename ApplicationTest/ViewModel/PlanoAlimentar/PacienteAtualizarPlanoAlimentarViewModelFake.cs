using Application.ViewModel.Pacientes;
using System;

namespace ApplicationTest.ViewModel.PlanoAlimentar
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
