using Application.Interfaces;
using Application.Interfaces.Mapper;
using Application.Pacientes.Commands;
using Application.ViewModel;
using Application.ViewModel.Pacientes;
using Core.Interfaces.Services;
using Domain.Entity;
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

        public ResponseView Add(PacienteAdicionarViewModel pacienteViewModel)
        {
            var command = new AdicionarPacienteCommand(pacienteViewModel);
            if (!command.EhValido())
                return new ResponseView(command.ValidationResult);

            var paciente = mapperPaciente.MapperViewModelToEntity(pacienteViewModel);
            servicePaciente.Add(paciente);

            return new ResponseView(paciente);
        }

        public async Task<IEnumerable<PacienteViewModel>> GetAll()
        {
            var pacientes = await servicePaciente.GetAll();
            return mapperPaciente.MapperListPacientesViewModel(pacientes);
        }

        public async Task<PacienteViewModel> GetById(Guid id)
        {
            var paciente = await GetPacienteById(id);
            return mapperPaciente.MapperEntityToViewModel(paciente);
        }

        public async Task RemoveById(Guid id)
        {
            await servicePaciente.RemoveById(id);
        }

        public void Update(PacienteViewModel pacienteViewModel)
        {
            var paciente = mapperPaciente.MapperViewModelToEntity(pacienteViewModel);
            servicePaciente.Update(paciente);
        }

        private async Task<Paciente> GetPacienteById(Guid id)
        {
            return await servicePaciente.GetById(id);
        }
    }
}