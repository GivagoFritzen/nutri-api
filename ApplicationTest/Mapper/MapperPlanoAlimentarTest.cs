using Application.Mapper;
using Application.ViewModel.Pacientes;
using ApplicationTest.ViewModel.PlanoAlimentar;
using Domain.Entity;
using DomainTest.Entity;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationTest.Mapper
{
    [TestClass]
    public class MapperPlanoAlimentarTest
    {
        [TestMethod]
        public void Model_To_Entity()
        {
            var model = PlanoAlimentarViewModelFake.GetFake();
            var expected = PlanoAlimentarEntityFake.GetFake();

            model.Refeicoes.Should()
                .BeEquivalentTo(expected.Refeicoes,
                options => options
                .Excluding(x => x.Id)
                .Excluding(x => x.Horario)
                .Excluding(x => x.Alimentos));

            CheckRefeicoes(expected.Refeicoes, model.Refeicoes).Should().BeTrue();
        }

        [TestMethod]
        public void Model_To_Entity_Null()
        {
            PlanoAlimentarViewModel model = null;
            model.ToEntity().Should().BeNull();
        }

        [TestMethod]
        public void List_Entity_To_Model()
        {
            var entities = PlanoAlimentarEntityFake.GetListFake();
            var expected = PlanoAlimentarViewModelFake.GetListFake();

            entities
                .Should()
                .BeEquivalentTo(expected,
                options => options
                .Excluding(x => x.Data));
        }

        [TestMethod]
        public void List_Entity_To_Model_Null()
        {
            List<PlanoAlimentarEntity> entities = null;
            entities.ToListPlanoAlimentarViewModel().Should().BeNull();
        }

        private bool CheckRefeicoes(List<RefeicaoEntity> refeicoesEntity, List<RefeicaoViewModel> refeicoesViewModel)
        {
            for (int i = 0; i < refeicoesEntity.Count(); i++)
            {
                if (refeicoesEntity[i].Alimentos == null && refeicoesViewModel[i].Alimentos != null ||
                    refeicoesEntity[i].Alimentos != null && refeicoesViewModel[i].Alimentos == null ||
                    refeicoesEntity[i].Alimentos.Count() != refeicoesViewModel[i].Alimentos.Count())
                {
                    return false;
                }

                if (CheckAlimentos(refeicoesEntity[i].Alimentos, refeicoesViewModel[i].Alimentos) == false)
                    return false;
            }

            return true;
        }

        private bool CheckAlimentos(List<AlimentoEntity> alimentosEntity, List<AlimentoViewModel> alimentosViewModel)
        {
            for (int i = 0; i < alimentosEntity.Count(); i++)
            {
                if (alimentosEntity[i].Nome != alimentosViewModel[i].Nome ||
                    alimentosEntity[i].Medida != alimentosViewModel[i].Medida ||
                    alimentosEntity[i].Quantidade != alimentosViewModel[i].Quantidade)
                    return false;
            }

            return true;
        }
    }
}
