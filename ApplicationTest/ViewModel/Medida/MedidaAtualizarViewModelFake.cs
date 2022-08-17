using Application.ViewModel.Medidas;
using System;

namespace ApplicationTest.ViewModel.Medida
{
    public static class MedidaAtualizarViewModelFake
    {
        public static MedidaAtualizarViewModel GetFake()
        {
            return new MedidaAtualizarViewModel()
            {
                PacienteId = Guid.NewGuid(),
                MedidaId = Guid.NewGuid(),
                Medida = MedidaViewModelFake.GetFake()
            };
        }
    }
}
