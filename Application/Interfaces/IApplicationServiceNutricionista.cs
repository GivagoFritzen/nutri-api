using Application.ViewModel;
using Application.ViewModel.Nutricionistas;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationServiceNutricionista
    {
        Task<BaseViewModel> Add(NutricionistaAdicionarViewModel nutricionistaViewModel);
        Task RemoveById(Guid id);
        BaseViewModel Update(NutricionistaAtualizarViewModel nutricionistaViewModel);
        Task<BaseViewModel> VincularPaciente(string PacienteEmail, StringValues token);
        Task<BaseViewModel> DesvincularPaciente(string emailDoPaciente, StringValues token);
        Task<NutricionistaViewModel> GetById(Guid id);
        Task<IEnumerable<NutricionistaViewModel>> GetAll();
        Task RemoverPacienteExcluido(Guid pacienteId);
    }
}