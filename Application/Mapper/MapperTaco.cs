using Application.ViewModel.Taco;
using Domain.DTO.Taco;

namespace Application.Mapper
{
    public static class MapperTaco
    {
        public static TacoPaginationViewModel ToViewModel(this TacoPaginationDTO dto)
        {
            return dto == null ? null : new TacoPaginationViewModel()
            {
                Data = dto.Data,
                Total = dto.Total
            };
        }
    }
}
