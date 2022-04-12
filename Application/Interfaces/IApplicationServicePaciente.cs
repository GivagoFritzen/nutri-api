using Application.ViewModel;
using Application.ViewModel.Pacientes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationServicePaciente
    {
        Task<ResponseView> Add(PacienteAdicionarViewModel pacienteViewModel);

        ResponseView Update(PacienteAtualizarViewModel pacienteViewModel);

        Task RemoveById(Guid id);

        Task<IEnumerable<PacienteSimplificadoViewModel>> GetAll();

        Task<PacienteViewModel> GetById(Guid id);
    }
}