using Application.DTO;
using Application.Interfaces.Mapper;
using Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Application.Mapper
{
    public class MapperPaciente : IMapperPaciente
    {
        public Paciente MapperDTOToEntity(PacienteDTO pacienteDTO)
        {
            return new Paciente()
            {
                Id = pacienteDTO.Id,
                Nome = pacienteDTO.Nome
            };
        }

        public PacienteDTO MapperEntityToDto(Paciente paciente)
        {
            return new PacienteDTO()
            {
                Id = paciente.Id,
                Nome = paciente.Nome
            };
        }

        public IEnumerable<PacienteDTO> MapperListPacientesDTO(IEnumerable<Paciente> pacientes)
        {
            return pacientes.Select(paciente => new PacienteDTO
            {
                Id = paciente.Id,
                Nome = paciente.Nome
            });
        }
    }
}