using Application.ViewModel.Pacientes;
using Application.ViewModel.Refeicao;
using ApplicationTest.ViewModel.Refeicao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationTest.ViewModel.Paciente
{
    public static class PacientePlanoAlimentarViewModelFake
    {
        public static PacientePlanoAlimentarViewModel GetFake()
        {
            return new PacientePlanoAlimentarViewModel()
            {
                PacienteId = Guid.NewGuid(),
                Refeicoes = RefeicaoViewModelFake.GetListFake().ToList()
            };
        }

        public static PacientePlanoAlimentarViewModel GetFakeRefeicaoNull()
        {
            return new PacientePlanoAlimentarViewModel()
            {
                PacienteId = Guid.NewGuid(),
                Refeicoes = null
            };
        }

        public static PacientePlanoAlimentarViewModel GetFakeRefeicaoEmpty()
        {
            return new PacientePlanoAlimentarViewModel()
            {
                PacienteId = Guid.NewGuid(),
                Refeicoes = new List<RefeicaoViewModel>()
            };
        }
    }
}
