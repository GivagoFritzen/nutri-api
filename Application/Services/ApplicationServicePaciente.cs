using Application.Interfaces;
using Application.Mapper;
using Application.Pacientes.Commands;
using Application.ViewModel;
using Application.ViewModel.Pacientes;
using Core.Interfaces.Services;
using Domain.Event;
using Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApplicationServicePaciente : IApplicationServicePaciente
    {
        private readonly IPacienteService pacienteService;
        private readonly IMessagingService messagingService;
        private readonly IUserService userService;

        public ApplicationServicePaciente(
            IPacienteService pacienteService,
            IMessagingService messagingService,
            IUserService userService)
        {
            this.pacienteService = pacienteService;
            this.messagingService = messagingService;
            this.userService = userService;
        }

        public async Task<ResponseView> Add(PacienteAdicionarViewModel pacienteViewModel)
        {
            var command = new AdicionarPacienteCommand(pacienteViewModel, userService);
            if (!command.EhValido())
                return new ResponseView(command.ValidationResult);

            var paciente = pacienteViewModel.ToEntity();
            await pacienteService.AddAsync(paciente);
            messagingService.Publish(paciente.ToEvent());
            messagingService.Publish(new UserEvent(paciente.Id, paciente.Email));

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
            messagingService.Publish(new UserEvent(id, true));
            messagingService.Publish(new PacienteEvent(id, true));
        }

        public ResponseView Update(PacienteViewModel pacienteViewModel)
        {
            var command = new AtualizarPacienteCommand(pacienteViewModel, userService);
            if (!command.EhValido())
                return new ResponseView(command.ValidationResult);

            messagingService.Publish(pacienteViewModel.ToPacienteEventUpdate());
            messagingService.Publish(new UserEvent(pacienteViewModel.Id, pacienteViewModel.Email, true));
            pacienteService.Update(pacienteViewModel.ToEntity());
            return new ResponseView(pacienteViewModel);
        }
    }
}