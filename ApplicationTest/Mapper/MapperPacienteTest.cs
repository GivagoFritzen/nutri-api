using Application.Mapper;
using Application.ViewModel.Pacientes;
using ApplicationTest.ViewModel.Paciente;
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
    public class MapperPacienteTest
    {
        [TestMethod]
        public void Adicionar_Model_To_Entity()
        {
            var model = PacienteAdicionarViewModelFake.GetFake();
            var expected = PacienteEntityFake.GetPacienteEntityFake();

            model.ToEntity()
                .Should()
                .BeEquivalentTo(expected,
                options => options
                .Excluding(_ => _.Id)
                .Excluding(_ => _.PlanosAlimentares));
        }

        [TestMethod]
        public void Adicionar_Model_To_Entity_Null()
        {
            PacienteAdicionarViewModel model = null;
            model.ToEntity().Should().BeNull();
        }

        [TestMethod]
        public void Entity_To_Model()
        {
            var entity = PacienteEntityFake.GetPacienteEntityFake();
            var expected = PacienteViewModelFake.GetDifferentIdFake(entity.Id);

            entity.ToViewModel()
                .Should()
                .BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Entity_To_Model_Null()
        {
            PacienteEntity entity = null;
            entity.ToViewModel().Should().BeNull();
        }

        [TestMethod]
        public void Event_To_Model()
        {
            var @event = PacienteEventFake.GetPacienteEventFake();
            var expected = PacienteViewModelFake.GetDifferentIdFake(@event.Id);

            @event.ToViewModel()
                .Should()
                .BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Event_To_Model_Null()
        {
            PacienteEvent entity = null;
            entity.ToViewModel().Should().BeNull();
        }

        [TestMethod]
        public void Events_To_List_Model_Empty()
        {
            var events = new List<PacienteEvent>();
            events.ToListPacientesViewModel().Should().BeEquivalentTo(new List<PacienteViewModel>());
        }

        [TestMethod]
        public void Events_To_List_Model()
        {
            var events = PacienteEventFake.GetListPacienteEventFake();
            var expected = PacienteViewModelFake.GetListDifferentIdFake(PacienteEventFake.Id);

            events.ToListPacientesViewModel().Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Events_To_List_Model_Null()
        {
            List<PacienteEvent> events = null;
            events.ToListPacientesViewModel().Should().BeNull();
        }

        [TestMethod]
        public void Events_To_List_Model_Simplificado_Empty()
        {
            var events = new List<PacienteEvent>();
            events.ToListPacientesSimplificadoViewModelViewModel().Should().BeEquivalentTo(new List<PacienteSimplificadoViewModel>());
        }

        [TestMethod]
        public void Events_To_List_Model_Simplificado()
        {
            var events = PacienteEventFake.GetListPacienteEventFake();
            var expected = PacienteSimplificadoViewModelFake.GetListDifferentIdFake(PacienteEventFake.Id);

            events.ToListPacientesSimplificadoViewModelViewModel().Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Events_To_List_Model_Simplificado_Null()
        {
            List<PacienteEvent> events = null;
            events.ToListPacientesSimplificadoViewModelViewModel().Should().BeNull();
        }

        [TestMethod]
        public void Entity_To_Event()
        {
            var entity = PacienteEntityFake.GetPacienteEntityFake();
            var expected = PacienteViewModelFake.GetDifferentIdFake(entity.Id);

            entity.ToEvent()
                .Should()
                .BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Entity_To_Event_Null()
        {
            PacienteEntity entity = null;
            entity.ToEvent().Should().BeNull();
        }

        [TestMethod]
        public void Model_To_Event_Update()
        {
            var model = PacienteAtualizarViewModelFake
                .GetFake()
                .ToEntity();
            var expected = PacienteEventFake.GetPacienteEventUpdateFake(model.Id);

            model.ToPacienteEventUpdate()
                .Should()
                .BeEquivalentTo(expected);
        }
    }
}
