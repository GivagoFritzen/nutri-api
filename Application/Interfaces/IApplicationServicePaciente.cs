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
        Task<ResponseView> Add(PacienteAdicionarViewModel pacienteViewModel);
        Task<ResponseView> Update(PacienteAtualizarViewModel pacienteViewModel);
        Task RemoveById(Guid id);
        Task<IEnumerable<PacienteSimplificadoViewModel>> GetAll(List<Guid> pacientesIds);
        Task<PacienteViewModel> GetById(Guid id);
        Task<ResponseView> AdicionarMedidas(MedidaAdicionarViewModel medidaViewModel);
        Task<ResponseView> AtualizarMedidas(MedidaAtualizarViewModel medidaViewModel);
        Task<ResponseView> AdicionarPlanoAlimentar(PacientePlanoAlimentarViewModel pacientePlanoAlimentarViewModel);
        ResponseView AtualizarPlanoAlimentar(PacienteAtualizarPlanoAlimentarViewModel pacienteAtualizarPlanoAlimentarViewModel);
    }
}