using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Mapper;
using Core.Interfaces.Services;
using System.Collections.Generic;

namespace Application.Services
{
    public class ApplicationServicePaciente : IApplicationServicePaciente
    {
        private readonly IPacienteService servicePaciente;
        private readonly IMapperPaciente mapperPaciente;

        public ApplicationServicePaciente(IPacienteService servicePaciente, IMapperPaciente mapperPaciente)
        {
            this.servicePaciente = servicePaciente;
            this.mapperPaciente = mapperPaciente;
        }

        public void Add(PacienteDTO pacienteDTO)
        {
            var paciente = mapperPaciente.MapperDTOToEntity(pacienteDTO);
            servicePaciente.Add(paciente);
        }

        public IEnumerable<PacienteDTO> GetAll()
        {
            var pacientes = servicePaciente.GetAll();
            return mapperPaciente.MapperListPacientesDTO(pacientes);
        }

        public PacienteDTO GetById(int id)
        {
            var paciente = servicePaciente.GetById(id);
            return mapperPaciente.MapperEntityToDto(paciente);
        }

        public void Remove(PacienteDTO pacienteDTO)
        {
            var paciente = mapperPaciente.MapperDTOToEntity(pacienteDTO);
            servicePaciente.Remove(paciente);
        }

        public void Update(PacienteDTO pacienteDTO)
        {
            var paciente = mapperPaciente.MapperDTOToEntity(pacienteDTO);
            servicePaciente.Update(paciente);
        }
    }
}