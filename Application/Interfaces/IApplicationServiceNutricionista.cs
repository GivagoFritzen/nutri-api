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
        Task<ResponseView> Add(NutricionistaAdicionarViewModel nutricionistaViewModel);
        Task RemoveById(Guid id);
        ResponseView Update(NutricionistaAtualizarViewModel nutricionistaViewModel);
        Task<ResponseView> VincularPaciente(NutricionistaDesvincularOuVincularViewModel nutricionistaViewModel);
        Task<ResponseView> DesvincularPaciente(string emailDoPaciente, StringValues token);
        Task<NutricionistaViewModel> GetById(Guid id);
        Task<IEnumerable<NutricionistaViewModel>> GetAll();
        Task<IEnumerable<PacienteSimplificadoViewModel>> GetPacientes(Guid id);
    }
}