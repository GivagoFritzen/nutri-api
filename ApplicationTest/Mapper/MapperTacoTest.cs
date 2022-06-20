using Application.Mapper;
using Domain.DTO.Taco;
using DomainTest.DTO;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationTest.Mapper
{
    [TestClass]
    public class MapperTacoTest
    {
        [TestMethod]
        public void Dto_To_ViewModel()
        {
            var dto = TacoPaginationDTOFake.GetFake();
            dto.ToViewModel().Should().BeEquivalentTo(dto);
        }

        [TestMethod]
        public void Dto_To_ViewModel_Null()
        {
            TacoPaginationDTO dto = null;
            dto.ToViewModel().Should().BeNull();
        }
    }
}
