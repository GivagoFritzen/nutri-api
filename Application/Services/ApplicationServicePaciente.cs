using Application.Interfaces;
using Application.Interfaces.Mapper;
using Application.Pacientes.Commands;
using Application.ViewModel;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public ResponseView Add(PacienteViewModel pacienteViewModel)
        {
            var response = new ResponseView();
            var command = new AdicionarPacienteCommand(pacienteViewModel);

            if (command.EhValido())
            {
                var paciente = mapperPaciente.MapperViewModelToEntity(pacienteViewModel);
                servicePaciente.Add(paciente);
                response.body = paciente;
            }
            else
            {
                response.AddMessageError(command.ValidationResult);
            }

            return response;
        }

        public async Task<IEnumerable<PacienteViewModel>> GetAll()
        {
            var pacientes = await servicePaciente.GetAll();
            return mapperPaciente.MapperListPacientesViewModel(pacientes);
        }

        public async Task<PacienteViewModel> GetById(Guid id)
        {
            var paciente = await servicePaciente.GetById(id);
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