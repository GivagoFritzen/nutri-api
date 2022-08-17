using Application.Mapper;
using Application.ViewModel.Medidas;
using ApplicationTest.ViewModel.Medida;
using Domain.Entity;
using DomainTest.Entity;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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

        [TestMethod]
        public void Update()
        {
            var entity = MedidaEntityFake.GetFake();
            var viewModel = new MedidaAtualizarViewModel()
            {
                PacienteId = Guid.NewGuid(),
                MedidaId = Guid.NewGuid(),
                Medida = new MedidaViewModel()
                {
                    Descricao = "descricao",
                    Data = DateTime.Now,
                    PesoAtual = 999999,
                    PesoIdeal = 999999,
                    Altura = 999999,
                    Circunferencia = null
                }
            };

            entity.Update(viewModel);
            entity.Should().BeEquivalentTo(viewModel.Medida);
        }

        [TestMethod]
        public void Update_Null()
        {
            MedidaEntity entity = null;
            var viewModel = new MedidaAtualizarViewModel()
            {
                PacienteId = Guid.NewGuid(),
                MedidaId = Guid.NewGuid(),
                Medida = new MedidaViewModel()
                {
                    Descricao = "descricao",
                    Data = DateTime.Now,
                    PesoAtual = 999999,
                    PesoIdeal = 999999,
                    Altura = 999999,
                    Circunferencia = null
                }
            };

            entity.Update(viewModel);
            entity.Should().BeNull();
        }
    }
}
