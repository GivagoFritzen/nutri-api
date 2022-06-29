using Application.ViewModel.Medidas;
using System;

namespace ApplicationTest.ViewModel.Medida
{
    public static class MedidaAdicionarViewModelFake
    {
        public static MedidaAdicionarViewModel GetFake()
        {
            return new MedidaAdicionarViewModel()
            {
                PacienteId = Guid.NewGuid(),
                Medida = MedidaViewModelFake.GetFake()
            };
        }
    }
}
