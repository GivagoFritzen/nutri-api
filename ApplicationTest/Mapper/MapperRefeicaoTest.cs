using Application.Mapper;
using Application.ViewModel.Pacientes;
using ApplicationTest.ViewModel.Refeicao;
using Domain.Entity;
using DomainTest.Entity;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ApplicationTest.Mapper
{
    [TestClass]
    public class MapperRefeicaoTest
    {
        [TestMethod]
        public void Lista_Refeicao_Model_To_Entity()
        {
            var model = RefeicaoViewModelFake.GetListFake();
            var expected = RefeicaoEntityFake.GetListFake();

            model.ToEntity()
                .Should()
                .BeEquivalentTo(expected,
                    options => options.Excluding(_ => _.Horario));
        }

        [TestMethod]
        public void Refeicao_Model_To_Entity_Null()
        {
            List<RefeicaoViewModel> viewModels = null;
            viewModels.ToEntity().Should().BeNull();
        }

        [TestMethod]
        public void Lista_Refeicoes_Entity_To_Model()
        {
            var entity = RefeicaoEntityFake.GetListFake();
            var expected = RefeicaoViewModelFake.GetListFake();

            entity.ToViewModel()
                .Should()
                .BeEquivalentTo(expected,
                    options => options.Excluding(_ => _.Horario));
        }

        [TestMethod]
        public void Lista_Refeicoes_Entity_To_Model_Null()
        {
            List<RefeicaoEntity> entities = null;
            entities.ToViewModel().Should().BeNull();
        }
    }
}
