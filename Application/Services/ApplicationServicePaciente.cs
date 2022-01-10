using Application.Interfaces;
using Application.Mapper;
using Application.Pacientes.Commands;
using Application.ViewModel;
using Application.ViewModel.Pacientes;
using Core.Interfaces.Services;
using Domain.Event;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApplicationServicePaciente : IApplicationServicePaciente
    {
        private readonly IPacienteService pacienteService;
        private readonly IMessagingService messagingService;

        public ApplicationServicePaciente(
            IPacienteService pacienteService,
            IMessagingService messagingService
            )
        {
            this.pacienteService = pacienteService;
            this.messagingService = messagingService;
        }

        public ResponseView Add(PacienteAdicionarViewModel pacienteViewModel)
        {
            var command = new AdicionarPacienteCommand(pacienteViewModel);
            if (!command.EhValido())
                return new ResponseView(command.ValidationResult);

            var paciente = pacienteViewModel.ToEntity();
            pacienteService.Add(paciente);
            messagingService.Publish(paciente);
            messagingService.Publish(new UserEvent() { Email = paciente.Email });

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