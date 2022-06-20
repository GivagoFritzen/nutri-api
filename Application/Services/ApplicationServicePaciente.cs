using Application.Commands.Pacientes;
using Application.Interfaces;
using Application.Mapper;
using Application.ViewModel;
using Application.ViewModel.Pacientes;
using CrossCutting.Helpers;
using Domain.Entity;
using Domain.Event;
using Domain.Interface.Repository;
using Domain.Interface.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApplicationServicePaciente : IApplicationServicePaciente
    {
        private readonly IPlanoAlimentarRepository planoAlimentarRepository;
        private readonly IPacienteRepository pacienteRepository;
        private readonly IMessagingService messagingService;
        private readonly IUserRepository userRepository;

        public ApplicationServicePaciente(
            IPlanoAlimentarRepository planoAlimentarRepository,
            IPacienteRepository pacienteRepository,
            IMessagingService messagingService,
            IUserRepository userRepository)
        {
            this.planoAlimentarRepository = planoAlimentarRepository;
            this.pacienteRepository = pacienteRepository;
            this.messagingService = messagingService;
            this.userRepository = userRepository;
        }

        public async Task<ResponseView> Add(PacienteAdicionarViewModel pacienteViewModel)
        {
            var command = new PacienteAdicionarCommand(pacienteViewModel, userRepository);
            if (!command.EhValido())
                return new ResponseView(command.ValidationResult);

            var paciente = pacienteViewModel.ToEntity();
            await pacienteRepository.AddAsync(paciente);
            SendMessageService(paciente.ToEvent());

            return new ResponseView(paciente.ToViewModel());
        }

        public async Task<IEnumerable<PacienteSimplificadoViewModel>> GetAll(List<Guid> pacientesIds)
        {
            var filter = Builders<PacienteEvent>.Filter.In("Id", pacientesIds);
            var fields = Builders<PacienteEvent>.Projection
                .Exclude(e => e.Cidade)
                .Exclude(e => e.Sexo)
                .Exclude(e => e.Medidas);

            var pacientes = await pacienteRepository.GetAll(filter, fields);
            return pacientes.ToListPacientesSimplificadoViewModelViewModel();
        }

        public async Task<PacienteViewModel> GetById(Guid id)
        {
            var paciente = await pacienteRepository.GetById(id);
            return paciente.ToViewModel();
        }

        public async Task RemoveById(Guid id)
        {
            await pacienteRepository.RemoveById(id);
            messagingService.Publish(new UserEvent(id, true));
            messagingService.Publish(new PacienteEvent(id, true));
        }

        public async Task<ResponseView> Update(PacienteAtualizarViewModel pacienteViewModel)
        {
            var command = new PacienteAtualizarCommand(pacienteViewModel, userRepository);
            if (!command.EhValido())
                return new ResponseView(command.ValidationResult);

            var entity = pacienteViewModel.ToEntity();
            var planosAlimentares = await pacienteRepository.GetPlanosByPacienteId(pacienteViewModel.Id);
            entity.PlanosAlimentares = planosAlimentares.ToList();

            SendMessageService(entity.ToPacienteEventUpdate(), true);
            pacienteRepository.Update(entity);

            return new ResponseView(pacienteViewModel);
        }

        public async Task<ResponseView> AdicionarPlanoAlimentar(PacientePlanoAlimentarViewModel pacientePlanoAlimentarViewModel)
        {
            var command = new PacientePlanoAlimentarCommand(pacientePlanoAlimentarViewModel, pacienteRepository);
            if (!command.EhValido())
                return new ResponseView(command.ValidationResult);

            var paciente = await pacienteRepository.GetById(pacientePlanoAlimentarViewModel.PacienteId);

            var refeicoes = pacientePlanoAlimentarViewModel.Refeicoes.ToEntity();

            if (paciente.PlanoAlimentares is null)
                paciente.PlanoAlimentares = new List<PlanoAlimentarEntity>();

            paciente.Update = true;
            paciente.PlanoAlimentares.Add(
                new PlanoAlimentarEntity()
                {
                    Data = DateTime.UtcNow,
                    Refeicoes = refeicoes.ToList()
                });

            SendMessageService(paciente, true);
            pacienteRepository.Update(paciente.ToEntity());

            return new ResponseView(pacientePlanoAlimentarViewModel);
        }

        public async Task<ResponseView> AtualizarPlanoAlimentar(PacienteAtualizarPlanoAlimentarViewModel pacienteAtualizarPlanoAlimentarViewModel)
        {
            var command = new PacienteAtualizarPlanoAlimentarCommand(pacienteAtualizarPlanoAlimentarViewModel, planoAlimentarRepository);
            if (!command.EhValido())
                return new ResponseView(command.ValidationResult);

            var planoAlimentar = await planoAlimentarRepository.GetById(pacienteAtualizarPlanoAlimentarViewModel.PlanoAlimentarId);


            var paciente = await pacienteRepository.GetById(planoAlimentar.PacienteId);
            //pacienteRepository.Update(pacienteAtualizarPlanoAlimentarViewModel.ToEntity());

            //Message

            return new ResponseView(pacienteAtualizarPlanoAlimentarViewModel);
        }

        private void SendMessageService(PacienteEvent pacienteEvent, bool update = false)
        {
            messagingService.Publish(pacienteEvent);
            messagingService.Publish(
               new UserEvent(
                    pacienteEvent.Id,
                    pacienteEvent.Email,
                    StringHelper.GetEventName(typeof(PacienteAtualizarViewModel).Name),
                    update));
        }
    }
}