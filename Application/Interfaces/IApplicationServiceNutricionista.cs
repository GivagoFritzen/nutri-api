using Application.ViewModel;
using Application.ViewModel.Nutricionistas;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationServiceNutricionista
    {
        ResponseView Add(NutricionistaAdicionarViewModel nutricionistaViewModel);

        ResponseView Update(NutricionistaAtualizarViewModel nutricionistaViewModel);

        Task<NutricionistaViewModel> GetById(Guid id);
    }
}