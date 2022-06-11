using Domain.Event.Taco;
using System.Collections.Generic;

namespace Application.ViewModel.Taco
{
    public class TacoPaginationViewModel
    {
        public List<TacoEvent> Data { get; set; }
        public int Total { get; set; }
    }
}