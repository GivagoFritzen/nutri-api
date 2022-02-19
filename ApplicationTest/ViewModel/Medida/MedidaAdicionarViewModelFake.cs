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
