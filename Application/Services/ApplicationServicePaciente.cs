using Application.ViewModel;
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

        public void Add(PacienteViewModel pacienteViewModel)
        {
            var paciente = mapperPaciente.MapperViewModelToEntity(pacienteViewModel);
            servicePaciente.Add(paciente);
        }

        public IEnumerable<PacienteViewModel> GetAll()
        {
            var pacientes = servicePaciente.GetAll();
            return mapperPaciente.MapperListPacientesViewModel(pacientes);
        }

        public PacienteViewModel GetById(int id)
        {
            var paciente = servicePaciente.GetById(id);
            return mapperPaciente.MapperEntityToViewModel(paciente);
        }

        public void Remove(PacienteViewModel pacienteViewModel)
        {
            var paciente = mapperPaciente.MapperViewModelToEntity(pacienteViewModel);
            servicePaciente.Remove(paciente);
        }

        public void Update(PacienteViewModel pacienteViewModel)
        {
            var paciente = mapperPaciente.MapperViewModelToEntity(pacienteViewModel);
            servicePaciente.Update(paciente);
        }
    }
}