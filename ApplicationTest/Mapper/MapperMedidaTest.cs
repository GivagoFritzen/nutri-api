using Application.Mapper;
using Application.ViewModel.Medidas;
using ApplicationTest.ViewModel.Medida;
using Domain.Entity;
using DomainTest.Entity;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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
                .FirstOrDefault()
                .Should()
                .BeEquivalentTo(expected,
                options => options.Excluding(_ => _.Id).Excluding(_ => _.Data));
        }

        [TestMethod]
        public void Adicionar_Model_To_Entity_Null()
        {
            MedidaAdicionarViewModel model = null;
            model.ToEntity().Should().BeEmpty();
        }

        [TestMethod]
        public void Model_To_Entity()
        {
            var model = new List<MedidaViewModel>() { MedidaViewModelFake.GetFake() };
            var expected = MedidaEntityFake.GetFake();

            model.ToEntity()
                .FirstOrDefault()
                .Should()
                .BeEquivalentTo(expected,
                options => options.Excluding(_ => _.Id).Excluding(_ => _.Data));
        }

        [TestMethod]
        public void Model_To_Entity_Null()
        {
            List<MedidaViewModel> models = null;
            models.ToEntity().Should().BeEmpty();
        }

        [TestMethod]
        public void Entity_To_Model()
        {
            var entity = new List<MedidaEntity>() { MedidaEntityFake.GetFake() };
            var expected = new List<MedidaViewModel>() { MedidaViewModelFake.GetFake() };

            entity.ToViewModel()
                .Should()
                .BeEquivalentTo(expected,
                options => options.Excluding(_ => _.Data));
        }

        [TestMethod]
        public void Entity_To_Model_Null()
        {
            List<MedidaEntity> entities = null;
            entities.ToViewModel().Should().BeEmpty();
        }
    }
}
