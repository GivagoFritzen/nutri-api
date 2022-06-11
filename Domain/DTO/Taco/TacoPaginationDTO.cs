using Domain.Event.Taco;
using System.Collections.Generic;

namespace Domain.DTO.Taco
{
    public class TacoPaginationDTO
    {
        public List<TacoEvent> Data { get; set; }
        public int Total { get; set; }
    }
}
