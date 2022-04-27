using Application.Commands.Nutricionistas;
using Application.Interfaces;
using Application.Mapper;
using Application.ViewModel;
using Application.ViewModel.Nutricionistas;
using Core.Interfaces.Services;
using CrossCutting.Helpers;
using Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApplicationServiceNutricionista : IApplicationServiceNutricionista
    {
        private readonly INutricionistaService nutricionistaService;
        private readonly IMessagingService messagingService;
        private readonly ISecurityService securityService;
        private readonly IUserService userService;
        private readonly IPacienteService pacienteService;

        public ApplicationServiceNutricionista(
            INutricionistaService nutricionistaService,
            IMessagingService messagingService,
            ISecurityService securityService,
            IUserService userService,
            IPacienteService pacienteService)
        {
            this.nutricionistaService = nutricionistaService;
            this.messagingService = messagingService;
            this.securityService = securityService;
            this.userService = userService;
            this.pacienteService = pacienteService;
        }

        public async Task<ResponseView> Add(NutricionistaAdicionarViewModel nutricionistaViewModel)
        {
            var command = new NutricionistaAdicionarCommand(nutricionistaViewModel, userService);
            if (!command.EhValido())
                return new ResponseView(command.ValidationResult);

            var nutricionista = nutricionistaViewModel.ToEntity();
            var passwordEncripted = securityService.EncryptPassword(nutricionista.Senha);
            nutricionista.Senha = passwordEncripted;

            await nutricionistaService.AddAsync(nutricionista);
            messagingService.Publish(nutricionista.ToNutricionistaEvent());
            messagingService.Publish(new UserEvent(nutricionista.Id, nutricionista.Email, StringHelper.GetEventName(typeof(NutricionistaViewModel).Name)));

            return new ResponseView(nutricionista.ToViewModel());
        }

        public async Task RemoveById(Guid id)
        {
            await nutricionistaService.RemoveById(id);
            messagingService.Publish(new UserEvent(id, true));
            messagingService.Publish(new NutricionistaEvent(id, true));
        }

        public async Task<NutricionistaViewModel> GetById(Guid id)
        {
            var nutricionista = await GetEventById(id);
            return nutricionista.ToViewModel();
        }

        public async Task<IEnumerable<NutricionistaViewModel>> GetAll()
        {
            var nutricionistas = await nutricionistaService.GetAll();
            return nutricionistas.ToViewModel();
        }

        public ResponseView Update(NutricionistaAtualizarViewModel nutricionistaViewModel)
        {
            var command = new NutricionistaAtualizarCommand(securityService, nutricionistaViewModel, userService);
            if (!command.EhValido())
                return new ResponseView(command.ValidationResult);

            messagingService.Publish(nutricionistaViewModel.ToNutricionistaEventUpdate());
            messagingService.Publish(
                new UserEvent(
                    nutricionistaViewModel.Id,
                    nutricionistaViewModel.Email,
                    StringHelper.GetEventName(typeof(NutricionistaAtualizarViewModel).Name),
                    true));
            nutricionistaService.Update(nutricionistaViewModel.ToEntity());
            return new ResponseView(nutricionistaViewModel);
        }

        public async Task<ResponseView> VincularPaciente(NutricionistaVincularViewModel nutricionistaViewModel)
        {
            var command = new NutricionistaVincularCommand(nutricionistaViewModel, userService);
            if (!command.EhValido())
                return new ResponseView(command.ValidationResult);

            var nutricionistaEvent = await GetEventById(nutricionistaViewModel.Id);
            if (nutricionistaEvent.PacientesIds == null)
                nutricionistaEvent.PacientesIds = new List<Guid>();

            var pacienteEvent = await pacienteService.GetByEmail(nutricionistaViewModel.PacienteEmail);
            nutricionistaEvent.PacientesIds.Remove(pacienteEvent.Id);

            var pacientes = (await pacienteService.GetAll()).Where(x => nutricionistaEvent.PacientesIds.Contains(x.Id));

            nutricionistaEvent.PacientesIds = new List<Guid>();
            nutricionistaEvent.PacientesIds.Add(pacienteEvent.Id);
            nutricionistaEvent.PacientesIds.AddRange(pacientes.Select(x => x.Id));

            var entity = nutricionistaEvent.ToEntity();
            entity.Pacientes.AddRange(pacientes.ToListPacientesEntity());

            nutricionistaEvent.Update = true;
            nutricionistaService.Update(entity);
            messagingService.Publish(nutricionistaEvent);

            return new ResponseView(nutricionistaViewModel);
        }

        private async Task<NutricionistaEvent> GetEventById(Guid id)
        {
            return await nutricionistaService.GetById(id);
        }
    }
}