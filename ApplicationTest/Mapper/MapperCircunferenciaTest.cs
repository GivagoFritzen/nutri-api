using Application.Mapper;
using Application.ViewModel.Medidas;
using ApplicationTest.ViewModel.Circunferencia;
using Domain.Entity.Medidas;
using DomainTest.Entity;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationTest.Mapper
{
    [TestClass]
    public class MapperCircunferenciaTest
    {
        [TestMethod]
        public void Model_To_Entity()
        {
            var model = CircunferenciaViewModelFake.GetFake();
            var expected = CircunferenciaEntityFake.GetFake();

            model.ToEntity()
                .Should()
                .BeEquivalentTo(expected,
                options => options.Excluding(_ => _.Id));
        }

        [TestMethod]
        public void Model_To_Entity_Null()
        {
            CircunferenciaViewModel model = null;
            model.ToEntity().Should().BeNull();
        }

        [TestMethod]
        public void Entity_To_Model()
        {
            var entity = CircunferenciaEntityFake.GetFake();
            var expected = CircunferenciaViewModelFake.GetFake();

            entity.ToViewModel()
                .Should()
                .BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Entity_To_Model_Null()
        {
            CircunferenciaEntity entity = null;
            entity.ToViewModel().Should().BeNull();
        }
    }
}
