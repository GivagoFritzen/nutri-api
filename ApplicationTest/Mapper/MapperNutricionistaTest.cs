using Application.Mapper;
using Application.ViewModel.Nutricionistas;
using ApplicationTest.ViewModel.Nutricionista;
using Domain.Entity;
using Domain.Event;
using DomainTest.Entity;
using DomainTest.Event;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ApplicationTest.Mapper
{
    [TestClass]
    public class MapperNutricionistaTest
    {
        [TestMethod]
        public void Adicionar_Model_To_Entity()
        {
            var model = NutricionistaAdicionarViewModelFake.GetFake();
            var expected = NutricionistaEntityFake.GetFake();

            model.ToEntity()
                .Should()
                .BeEquivalentTo(expected,
                options => options.Excluding(_ => _.Id));
        }

        [TestMethod]
        public void Adicionar_Model_To_Entity_Null()
        {
            NutricionistaAdicionarViewModel model = null;
            model.ToEntity().Should().BeNull();
        }

        [TestMethod]
        public void Model_To_Entity()
        {
            var model = NutricionistaAtualizarViewModelFake.GetFake();
            var expected = NutricionistaEntityFake.GetFake();

            model.ToEntity()
                .Should()
                .BeEquivalentTo(expected,
                options => options.Excluding(_ => _.Id));
        }

        [TestMethod]
        public void Model_To_Entity_Null()
        {
            NutricionistaAtualizarViewModel model = null;
            model.ToEntity().Should().BeNull();
        }

        [TestMethod]
        public void Entity_To_Model()
        {
            var entity = NutricionistaEntityFake.GetFake();
            var expected = NutricionistaViewModelFake.GetFake();

            entity.ToViewModel().Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Entity_To_Model_Null()
        {
            NutricionistaEntity entity = null;
            entity.ToViewModel().Should().BeNull();
        }

        [TestMethod]
        public void Event_To_Model()
        {
            var @event = NutricionistaEventFake.GetFake();
            var expected = NutricionistaViewModelFake.GetFake();

            @event.ToViewModel().Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Event_To_Model_Null()
        {
            NutricionistaEvent @event = null;
            @event.ToViewModel().Should().BeNull();
        }

        [TestMethod]
        public void Events_To_List_Model_Empty()
        {
            var events = new List<NutricionistaEvent>();
            events.ToViewModel().Should().BeEquivalentTo(new List<NutricionistaViewModel>());
        }

        [TestMethod]
        public void Events_To_List_Model()
        {
            var events = NutricionistaEventFake.GetListFake();
            var expected = NutricionistaViewModelFake.GetListFake();

            @events.ToViewModel().Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Events_To_List_Model_Null()
        {
            List<NutricionistaEvent> events = null;
            events.ToViewModel().Should().BeNull();
        }

        [TestMethod]
        public void Entity_To_Event()
        {
            var entity = NutricionistaEntityFake.GetFake();
            var expected = NutricionistaEventFake.GetFake();

            entity.ToNutricionistaEvent().Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Entity_To_Event_Null()
        {
            NutricionistaEntity entity = null;
            entity.ToNutricionistaEvent().Should().BeNull();
        }

        [TestMethod]
        public void Model_To_Event_Update()
        {
            var model = NutricionistaAtualizarViewModelFake.GetFake();
            var expected = NutricionistaEventFake.GetUpdateFake();

            model.ToNutricionistaEventUpdate()
                .Should()
                .BeEquivalentTo(expected);
        }
    }
}
