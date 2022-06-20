using Application.Mapper;
using Application.ViewModel.Pacientes;
using ApplicationTest.ViewModel.Alimento;
using Domain.Entity;
using DomainTest.Entity;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationTest.Mapper
{
    [TestClass]
    public class MapperAlimentacaoTest
    {
        [TestMethod]
        public void Lista_Alimentos_Model_To_Entity()
        {
            var model = AlimentoViewModelFake.GetListFake().ToList();
            var expected = AlimentoEntityFake.GetListFake();

            model.ToEntity()
                .Should()
                .BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Lista_Alimentos_Model_To_Entity_Null()
        {
            List<AlimentoViewModel> viewModels = null;
            viewModels.ToEntity().Should().BeNull();
        }

        [TestMethod]
        public void Lista_Alimentos_Entity_To_Model()
        {
            var entity = AlimentoEntityFake.GetListFake().ToList();
            var expected = AlimentoViewModelFake.GetListFake();

            entity.ToViewModel()
                .Should()
                .BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Lista_Alimentos_Entity_To_Model_Null()
        {
            List<AlimentoEntity> entities = null;
            entities.ToViewModel().Should().BeNull();
        }
    }
}
