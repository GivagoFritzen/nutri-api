using Application.Mapper;
using Application.ViewModel.Admin;
using ApplicationTest.ViewModel.Admin;
using Domain.Entity;
using Domain.Event;
using DomainTest.Entity;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationTest.Mapper
{
    [TestClass]
    public class MapperAdminTest
    {
        [TestMethod]
        public void Model_To_Entity()
        {
            var model = AdminViewModelFake.GetAdminAdicionarViewModelFake();
            var expected = AdminEntityFake.GetAdminEntitySemIdFake(model.Senha, model.Email);

            model.ToEntity()
                .Should()
                .BeEquivalentTo(expected,
                options => options.Excluding(_ => _.Id));
        }

        [TestMethod]
        public void Model_To_Entity_Null()
        {
            AdminAdicionarViewModel model = null;
            model.ToEntity().Should().BeNull();
        }

        [TestMethod]
        public void Entity_To_Model()
        {
            var entity = AdminEntityFake.GetAdminEntitySemIdFake();
            var expected = AdminViewModelFake.GetAdminAdicionarViewModelFake(entity.Senha, entity.Email);

            entity.ToViewModel()
                .Should()
                .BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Entity_To_Model_Null()
        {
            AdminEntity entity = null;
            entity.ToViewModel().Should().BeNull();
        }

        [TestMethod]
        public void Entity_To_Event()
        {
            var entity = AdminEntityFake.GetAdminEntitySemSenhaFake();

            var expected = new AdminEvent()
            {
                Id = entity.Id,
                Email = entity.Email
            };

            entity.ToAdminEvent()
                .Should()
                .BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Entity_To_Event_Null()
        {
            AdminEntity entity = null;
            entity.ToAdminEvent().Should().BeNull();
        }
    }
}
