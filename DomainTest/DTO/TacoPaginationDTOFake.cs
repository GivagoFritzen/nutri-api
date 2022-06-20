using Domain.DTO.Taco;
using DomainTest.Event.Taco;

namespace DomainTest.DTO
{
    public static class TacoPaginationDTOFake
    {
        public static TacoPaginationDTO GetFake()
        {
            return new TacoPaginationDTO()
            {
                Data = TacoEventFake.GetListFake(),
                Total = 1
            };
        }
    }
}
