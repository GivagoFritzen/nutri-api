using Application.Mapper;
using Application.ViewModel.Medidas;
using ApplicationTest.ViewModel.Medida;
using Domain.Entity;
using DomainTest.Entity;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ApplicationTest.Mapper
{
    [TestClass]
    public class MapperMedidaTest
    {
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
