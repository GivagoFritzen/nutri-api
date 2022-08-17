using Application.Commands.Nutricionistas;
using Application.Interfaces;
using Application.Mapper;
using Application.ViewModel;
using Application.ViewModel.Nutricionistas;
using CrossCutting.Helpers;
using Domain.Entity;
using Domain.Event;
using Domain.Interface.Repository;
using Domain.Interface.Services;
using Microsoft.Extensions.Primitives;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApplicationServiceNutricionista : IApplicationServiceNutricionista
    {
        private readonly INutricionistaRepository nutricionistaRepository;
        private readonly IMessagingService messagingService;
        private readonly ISecurityService securityService;
        private readonly IUserRepository userRepository;
        private readonly IPacienteRepository pacienteService;
        private readonly ITokenService tokenService;

        public ApplicationServiceNutricionista(
            INutricionistaRepository nutricionistaRepository,
            IMessagingService messagingService,
            ISecurityService securityService,
            IUserRepository userRepository,
            IPacienteRepository pacienteService,
            ITokenService tokenService)
        {
            this.nutricionistaRepository = nutricionistaRepository;
            this.messagingService = messagingService;
            this.securityService = securityService;
            this.userRepository = userRepository;
            this.pacienteService = pacienteService;
            this.tokenService = tokenService;
        }

        public async Task<BaseViewModel> Add(NutricionistaAdicionarViewModel nutricionistaViewModel)
        {
            var command = new NutricionistaAdicionarCommand(nutricionistaViewModel, userRepository);
            if (!command.EhValido())
                return new ErrorViewModel(command.ValidationResult);

            var nutricionista = nutricionistaViewModel.ToEntity();
            nutricionista.Senha = securityService.EncryptPassword(nutricionista.Senha);

            await nutricionistaRepository.AddAsync(nutricionista);
            messagingService.Publish(nutricionista.ToNutricionistaEvent());
            messagingService.Publish(new UserEvent(nutricionista.Id, nutricionista.Email, StringHelper.GetEventName(typeof(NutricionistaViewModel).Name)));

            return nutricionista.ToViewModel();
        }

        public async Task RemoveById(Guid id)
        {
            await nutricionistaRepository.RemoveById(id);
            messagingService.Publish(new UserEvent(id, true));
            messagingService.Publish(new NutricionistaEvent(id, true));
        }

        public async Task<NutricionistaViewModel> GetById(Guid id)
        {
            var nutricionista = await nutricionistaRepository.GetById(id);
            return nutricionista.ToViewModel();
        }

        public async Task<IEnumerable<NutricionistaViewModel>> GetAll()
        {
            var nutricionistas = await nutricionistaRepository.GetAll();
            return nutricionistas.ToViewModel();
        }

        public BaseViewModel Update(NutricionistaAtualizarViewModel nutricionistaViewModel)
        {
            var command = new NutricionistaAtualizarCommand(securityService, nutricionistaViewModel, userRepository);
            if (!command.EhValido())
                return new ErrorViewModel(command.ValidationResult);

            nutricionistaViewModel.NovaSenha = securityService.EncryptPassword(nutricionistaViewModel.NovaSenha);
            UpdateRepositories(nutricionistaViewModel.ToNutricionistaEventUpdate(), nutricionistaViewModel.ToEntity());

            messagingService.Publish(
                new UserEvent(
                    nutricionistaViewModel.Id,
                    nutricionistaViewModel.Email,
                    StringHelper.GetEventName(typeof(NutricionistaEvent).Name),
                true));

            return nutricionistaViewModel;
        }

        public async Task<BaseViewModel> VincularPaciente(string PacienteEmail, StringValues token)
        {
            var nutricionistaViewModel = new NutricionistaDesvincularOuVincularViewModel()
            {
                Id = tokenService.GetInformacoesDoToken(token.ToString()).Id,
                PacienteEmail = PacienteEmail
            };

            var command = new NutricionistaDesvincularOuVincularCommand(nutricionistaViewModel, userRepository);
            if (!command.EhValido())
                return new ErrorViewModel(command.ValidationResult);

            var nutricionistaEvent = await nutricionistaRepository.GetById(nutricionistaViewModel.Id);
            if (nutricionistaEvent.PacientesIds == null)
                nutricionistaEvent.PacientesIds = new List<Guid>();

            var pacienteEvent = await pacienteService.GetByEmail(nutricionistaViewModel.PacienteEmail);

            var pacientes = (await pacienteService.GetAll())
                .Where(x => nutricionistaEvent.PacientesIds.Contains(x.Id))
                .ToList();

            nutricionistaEvent.PacientesIds.Add(pacienteEvent.Id);
            nutricionistaEvent.PacientesIds.AddRange(pacientes.Select(x => x.Id));
            nutricionistaEvent.PacientesIds = nutricionistaEvent.PacientesIds.Distinct().ToList();

            var entity = nutricionistaEvent.ToEntity();
            entity.Pacientes.Add(pacienteEvent.ToEntity());
            entity.Pacientes.AddRange(pacientes.ToListPacientesEntity());

            UpdateRepositories(nutricionistaEvent, entity);

            return nutricionistaViewModel;
        }

        public async Task<BaseViewModel> DesvincularPaciente(string emailDoPaciente, StringValues token)
        {
            var nutricionistaViewModel = new NutricionistaDesvincularOuVincularViewModel()
            {
                PacienteEmail = emailDoPaciente,
                Id = tokenService.GetInformacoesDoToken(token.ToString()).Id
            };

            var command = new NutricionistaDesvincularOuVincularCommand(nutricionistaViewModel, userRepository);
            if (!command.EhValido())
                return new ErrorViewModel(command.ValidationResult);

            var nutricionistaEvent = await nutricionistaRepository.GetById(nutricionistaViewModel.Id);

            var pacienteEvent = await pacienteService.GetByEmail(nutricionistaViewModel.PacienteEmail);
            nutricionistaEvent.PacientesIds.Remove(pacienteEvent.Id);

            UpdateRepositories(nutricionistaEvent, nutricionistaEvent.ToEntity());
            return nutricionistaViewModel;
        }

        public async Task RemoverPacienteExcluido(Guid pacienteId)
        {
            var filter = Builders<NutricionistaEvent>.Filter.In("PacientesIds", new List<Guid>() { pacienteId });
            var fields = Builders<NutricionistaEvent>.Projection.Include(x => x.PacientesIds);

            var nutricionistas = await nutricionistaRepository.GetAll(filter, fields);

            foreach (var nutricionista in nutricionistas)
            {
                nutricionista.PacientesIds.Remove(pacienteId);
                UpdateRepositories(nutricionista, nutricionista.ToEntity());
            }
        }

        private void UpdateRepositories(NutricionistaEvent nutricionistaEvent, NutricionistaEntity entity)
        {
            nutricionistaEvent.Update = true;

            messagingService.Publish(nutricionistaEvent);
            nutricionistaRepository.Update(entity);
        }
    }
}