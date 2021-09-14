using Application.Interfaces;
using Application.Mapper;
using Application.Pacientes.Commands;
using Application.ViewModel;
using Application.ViewModel.Pacientes;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApplicationServicePaciente : IApplicationServicePaciente
    {
        private readonly IPacienteService pacienteService;

        public ApplicationServicePaciente(IPacienteService pacienteService)
        {
            this.pacienteService = pacienteService;
        }

        public ResponseView Add(PacienteAdicionarViewModel pacienteViewModel)
        {
            var command = new AdicionarPacienteCommand(pacienteViewModel);
            if (!command.EhValido())
                return new ResponseView(command.ValidationResult);

            var paciente = pacienteViewModel.ToEntity();
            pacienteService.Add(paciente);

            return new ResponseView(paciente.ToViewModel());
        }

        public async Task<IEnumerable<PacienteViewModel>> GetAll()
        {
            var pacientes = await pacienteService.GetAll();
            return pacientes.ToListPacientesViewModel();
        }

        public async Task<PacienteViewModel> GetById(Guid id)
        {
            var paciente = await pacienteService.GetById(id);
            return paciente.ToViewModel();
        }

        public async Task RemoveById(Guid id)
        {
            await pacienteService.RemoveById(id);
        }

        public void Update(PacienteViewModel pacienteViewModel)
        {
            pacienteService.Update(pacienteViewModel.ToEntity());
        }
    }
}