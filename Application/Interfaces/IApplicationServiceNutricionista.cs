using Application.ViewModel;
using Application.ViewModel.Nutricionistas;
using Application.ViewModel.Pacientes;
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
        Task<BaseViewModel> VincularPaciente(NutricionistaDesvincularOuVincularViewModel nutricionistaViewModel);
        Task<BaseViewModel> DesvincularPaciente(string emailDoPaciente, StringValues token);
        Task<NutricionistaViewModel> GetById(Guid id);
        Task<IEnumerable<NutricionistaViewModel>> GetAll();
        Task<IEnumerable<PacienteSimplificadoViewModel>> GetPacientes(Guid id);
    }
}