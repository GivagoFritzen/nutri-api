using Application.ViewModel.PlanosAlimentares;
using ApplicationTest.ViewModel.Refeicao;
using CrossCuttingTest;
using System.Collections.Generic;

namespace ApplicationTest.ViewModel.PlanoAlimentar
{
    public static class PlanoAlimentarViewModelFake
    {
        public static PlanoAlimentarViewModel GetFake()
        {
            return new PlanoAlimentarViewModel()
            {
                Data = DataFake.GetDateTime(),
                Refeicoes = RefeicaoViewModelFake.GetListFake()
            };
        }

        public static List<PlanoAlimentarViewModel> GetListFake()
        {
            return new List<PlanoAlimentarViewModel>()
            {
                GetFake()
            };
        }
    }
}
