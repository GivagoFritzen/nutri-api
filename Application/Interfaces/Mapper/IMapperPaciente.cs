using Application.ViewModel.Pacientes;
using Domain.Entity;
using System.Collections.Generic;

namespace Application.Interfaces.Mapper
{
    public interface IMapperPaciente
    {
        Paciente MapperViewModelToEntity(PacienteAdicionarViewModel pacienteViewModel);

        Paciente MapperViewModelToEntity(PacienteViewModel pacienteViewModel);

        PacienteViewModel MapperEntityToViewModel(Paciente paciente);

        IEnumerable<PacienteViewModel> MapperListPacientesViewModel(IEnumerable<Paciente> pacientes);
    }
}