using Application.ViewModel;
using Application.ViewModel.Nutricionistas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationServiceNutricionista
    {
        ResponseView Add(NutricionistaAdicionarViewModel nutricionistaViewModel);

        Task RemoveById(Guid id);

        ResponseView Update(NutricionistaAtualizarViewModel nutricionistaViewModel);

        Task<NutricionistaViewModel> GetById(Guid id);

        Task<IEnumerable<NutricionistaViewModel>> GetAll();
    }
}