using Application.Mapper;
using Application.ViewModel.Medidas;
using ApplicationTest.ViewModel.Medida;
using Domain.Entity;
using DomainTest.Entity;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationTest.Mapper
{
    [TestClass]
    public class MapperMedidaTest
    {
        [TestMethod]
        public void Adicionar_Model_To_Entity()
        {
            var model = MedidaAdicionarViewModelFake.GetFake();
            var expected = MedidaEntityFake.GetFake();

            model.ToEntity()
                .Should()
                .BeEquivalentTo(expected,
                options => options.Excluding(_ => _.Id).Excluding(_ => _.Data));
        }

        [TestMethod]
        public void Adicionar_Model_To_Entity_Null()
        {
            MedidaAdicionarViewModel model = null;
            model.ToEntity().Should().BeNull();
        }

        [TestMethod]
        public void Model_To_Entity()
        {
            var model = MedidaViewModelFake.GetFake();
            var expected = MedidaEntityFake.GetFake();

            model.ToEntity()
                .Should()
                .BeEquivalentTo(expected,
                options => options.Excluding(_ => _.Id).Excluding(_ => _.Data));
        }

        [TestMethod]
        public void Model_To_Entity_Null()
        {
            MedidaViewModel model = null;
            model.ToEntity().Should().BeNull();
        }

        [TestMethod]
        public void Entity_To_Model()
        {
            var entity = MedidaEntityFake.GetFake();
            var expected = MedidaViewModelFake.GetFake();

            entity.ToViewModel()
                .Should()
                .BeEquivalentTo(expected,
                options => options.Excluding(_ => _.Data));
        }

        [TestMethod]
        public void Entity_To_Model_Null()
        {
            MedidaEntity entity = null;
            entity.ToViewModel().Should().BeNull();
        }
    }
}
