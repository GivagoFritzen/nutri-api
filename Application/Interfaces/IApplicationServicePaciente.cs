using Application.ViewModel;
using Application.ViewModel.Medidas;
using Application.ViewModel.Pacientes;
using Application.ViewModel.PlanosAlimentares;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationServicePaciente
    {
        Task<BaseViewModel> Add(PacienteAdicionarViewModel pacienteViewModel, StringValues token);
        Task<BaseViewModel> Update(PacienteAtualizarViewModel pacienteViewModel, StringValues token);
        Task RemoveById(Guid id);
        Task<PacienteViewModel> GetById(Guid id);
        Task<PacientePaginationViewModel> GetAll(string email, int paginaAtual);
        Task<IEnumerable<PacienteSimplificadoViewModel>> GetPacientes(StringValues token);
        Task<IEnumerable<PacienteSimplificadoViewModel>> GetAll(List<Guid> pacientesIds);
        Task<List<MedidaViewModel>> GetAllMedidas(Guid pacienteId);
        Task<BaseViewModel> AdicionarMedidas(MedidaAdicionarViewModel medidaViewModel);
        Task<BaseViewModel> AtualizarMedidas(MedidaAtualizarViewModel medidaViewModel);
        Task<IEnumerable<PlanoAlimentarViewModel>> GetAllPlanosAlimenares(Guid pacienteId);
        Task<BaseViewModel> AdicionarPlanoAlimentar(PacientePlanoAlimentarViewModel pacientePlanoAlimentarViewModel);
        BaseViewModel AtualizarPlanoAlimentar(PacienteAtualizarPlanoAlimentarViewModel pacienteAtualizarPlanoAlimentarViewModel);
    }
}