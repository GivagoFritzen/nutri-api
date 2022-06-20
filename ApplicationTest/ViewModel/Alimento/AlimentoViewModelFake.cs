using Application.ViewModel.Pacientes;
using Domain.Enums;
using System.Collections.Generic;

namespace ApplicationTest.ViewModel.Alimento
{
    public static class AlimentoViewModelFake
    {
        public static AlimentoViewModel GetFake()
        {
            return new AlimentoViewModel()
            {
                Nome = "nome",
                Medida = MedidaCaseira.Grama,
                Quantidade = 1
            };
        }

        public static IEnumerable<AlimentoViewModel> GetListFake()
        {
            return new List<AlimentoViewModel>
            {
                GetFake()
            };
        }

        public static AlimentoViewModel GetFakeNomeNull()
        {
            return new AlimentoViewModel()
            {
                Nome = null,
                Medida = MedidaCaseira.Grama,
                Quantidade = 1
            };
        }

        public static AlimentoViewModel GetFakeNomeEmpty()
        {
            return new AlimentoViewModel()
            {
                Nome = "",
                Medida = MedidaCaseira.Grama,
                Quantidade = 1
            };
        }

        public static AlimentoViewModel GetFakeAlimentoQuantidadeZero()
        {
            return new AlimentoViewModel()
            {
                Nome = "nome",
                Medida = MedidaCaseira.Grama,
                Quantidade = 0
            };
        }

        public static AlimentoViewModel GetFakeAlimentoQuantidadeNegativa()
        {
            return new AlimentoViewModel()
            {
                Nome = "",
                Medida = MedidaCaseira.Grama,
                Quantidade = -1
            };
        }
    }
}
