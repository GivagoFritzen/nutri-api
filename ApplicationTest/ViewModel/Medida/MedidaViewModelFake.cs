using Application.ViewModel.Medidas;
using System;

namespace ApplicationTest.ViewModel.Medida
{
    public static class MedidaViewModelFake
    {
        public static MedidaViewModel GetFake()
        {
            return new MedidaViewModel()
            {
                Descricao = "descricao",
                Data = DateTime.Now,
                PesoAtual = 10,
                PesoIdeal = 12,
                Altura = 2,
                Circunferencia = null
            };
        }
    }
}
