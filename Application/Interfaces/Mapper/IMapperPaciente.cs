using Application.DTO;
using Domain.Entity;
using System.Collections.Generic;

namespace Application.Interfaces.Mapper
{
    public interface IMapperPaciente
    {
        Paciente MapperDTOToEntity(PacienteDTO pacienteDTO);

        PacienteDTO MapperEntityToDto(Paciente paciente);

        IEnumerable<PacienteDTO> MapperListPacientesDTO(IEnumerable<Paciente> pacientes);
    }
}