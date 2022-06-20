using Application.ViewModel.Pacientes;
using ApplicationTest.ViewModel.Alimento;
using CrossCuttingTest;
using System;
using System.Collections.Generic;

namespace ApplicationTest.ViewModel.Refeicao
{
    public static class RefeicaoViewModelFake
    {
        public static RefeicaoViewModel GetFake()
        {
            return new RefeicaoViewModel()
            {
                Horario = DataFake.GetDateTime(),
                Descricao = "descricao",
                Alimentos = new List<AlimentoViewModel>()
                {
                    AlimentoViewModelFake.GetFake()
                }
            };
        }

        public static RefeicaoViewModel GetFakeDescricaoNull()
        {
            return new RefeicaoViewModel()
            {
                Horario = DateTime.Now,
                Descricao = null,
                Alimentos = new List<AlimentoViewModel>()
                {
                    AlimentoViewModelFake.GetFake()
                }
            };
        }

        public static RefeicaoViewModel GetFakeDescricaoVazia()
        {
            return new RefeicaoViewModel()
            {
                Horario = DateTime.Now,
                Descricao = "",
                Alimentos = new List<AlimentoViewModel>()
                {
                    AlimentoViewModelFake.GetFake()
                }
            };
        }

        public static RefeicaoViewModel GetFakeAlimentoNull()
        {
            return new RefeicaoViewModel()
            {
                Horario = DateTime.Now,
                Descricao = "descricao",
                Alimentos = null
            };
        }

        public static RefeicaoViewModel GetFakeAlimentoVazia()
        {
            return new RefeicaoViewModel()
            {
                Horario = DateTime.Now,
                Descricao = "descricao",
                Alimentos = new List<AlimentoViewModel>()
            };
        }

        public static RefeicaoViewModel GetFakeAlimentoNomeNull()
        {
            return new RefeicaoViewModel()
            {
                Horario = DateTime.Now,
                Descricao = "descricao",
                Alimentos = new List<AlimentoViewModel>()
                {
                    AlimentoViewModelFake.GetFakeNomeNull()
                }
            };
        }

        public static RefeicaoViewModel GetFakeAlimentoNomeEmpty()
        {
            return new RefeicaoViewModel()
            {
                Horario = DateTime.Now,
                Descricao = "descricao",
                Alimentos = new List<AlimentoViewModel>()
                {
                    AlimentoViewModelFake.GetFakeNomeEmpty()
                }
            };
        }

        public static RefeicaoViewModel GetFakeAlimentoQuantidadeZero()
        {
            return new RefeicaoViewModel()
            {
                Horario = DateTime.Now,
                Descricao = "descricao",
                Alimentos = new List<AlimentoViewModel>()
                {
                    AlimentoViewModelFake.GetFakeAlimentoQuantidadeZero()
                }
            };
        }

        public static RefeicaoViewModel GetFakeAlimentoQuantidadeNegativa()
        {
            return new RefeicaoViewModel()
            {
                Horario = DateTime.Now,
                Descricao = "descricao",
                Alimentos = new List<AlimentoViewModel>()
                {
                    AlimentoViewModelFake.GetFakeAlimentoQuantidadeNegativa()
                }
            };
        }

        public static List<RefeicaoViewModel> GetListFake()
        {
            return new List<RefeicaoViewModel>()
            {
                GetFake()
            };
        }
    }
}
