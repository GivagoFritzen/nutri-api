using Application.ViewModel;
using Application.ViewModel.Medidas;
using Application.ViewModel.Pacientes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationServicePaciente
    {
        Task<BaseViewModel> Add(PacienteAdicionarViewModel pacienteViewModel);
        Task<BaseViewModel> Update(PacienteAtualizarViewModel pacienteViewModel);
        Task RemoveById(Guid id);
        Task<IEnumerable<PacienteSimplificadoViewModel>> GetAll(List<Guid> pacientesIds);
        Task<PacienteViewModel> GetById(Guid id);
        Task<BaseViewModel> AdicionarMedidas(MedidaAdicionarViewModel medidaViewModel);
        Task<BaseViewModel> AtualizarMedidas(MedidaAtualizarViewModel medidaViewModel);
        Task<BaseViewModel> AdicionarPlanoAlimentar(PacientePlanoAlimentarViewModel pacientePlanoAlimentarViewModel);
        BaseViewModel AtualizarPlanoAlimentar(PacienteAtualizarPlanoAlimentarViewModel pacienteAtualizarPlanoAlimentarViewModel);
    }
}