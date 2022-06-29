using Application.Commands.Medidas;
using Application.Commands.Pacientes;
using Application.Interfaces;
using Application.Mapper;
using Application.ViewModel;
using Application.ViewModel.Medidas;
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
        private readonly IMedidaRepository medidaRepository;
        private readonly IMessagingService messagingService;
        private readonly IUserRepository userRepository;

        public ApplicationServicePaciente(
            IPlanoAlimentarRepository planoAlimentarRepository,
            IPacienteRepository pacienteRepository,
            IMedidaRepository medidaRepository,
            IMessagingService messagingService,
            IUserRepository userRepository)
        {
            this.planoAlimentarRepository = planoAlimentarRepository;
            this.pacienteRepository = pacienteRepository;
            this.medidaRepository = medidaRepository;
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
            var medidas = await pacienteRepository.GetMedidasByPacienteId(pacienteViewModel.Id);

            entity.PlanosAlimentares = planosAlimentares.ToList();
            entity.Medidas = medidas.ToList();

            SendMessageService(entity.ToPacienteEventUpdate(), true);
            pacienteRepository.Update(entity);

            return new ResponseView(pacienteViewModel);
        }

        public async Task<ResponseView> AdicionarMedidas(MedidaAdicionarViewModel medidaViewModel)
        {
            var command = new MedidaAdicionarCommand(medidaViewModel, pacienteRepository);
            if (!command.EhValido())
                return new ResponseView(command.ValidationResult);

            var paciente = (await pacienteRepository.GetById(medidaViewModel.PacienteId)).ToEntity();

            if (paciente.Medidas is null)
                paciente.Medidas = new List<MedidaEntity>();

            var medida = medidaViewModel.Medida.ToEntity();
            paciente.Medidas.Add(medida);

            pacienteRepository.Update(paciente);
            messagingService.Publish(paciente.ToPacienteEventUpdate());

            return new ResponseView(medidaViewModel);
        }

        public async Task<ResponseView> AtualizarMedidas(MedidaAtualizarViewModel medidaViewModel)
        {
            var command = new MedidaAtualizarCommand(medidaViewModel, medidaRepository, pacienteRepository);
            if (!command.EhValido())
                return new ResponseView(command.ValidationResult);

            var medida = await medidaRepository.GetById(medidaViewModel.MedidaId);
            medida.Update(medidaViewModel);
            medidaRepository.Update(medida);

            var pacienteEvent = await pacienteRepository.GetById(medidaViewModel.PacienteId);
            pacienteEvent.Update = true;
            messagingService.Publish(pacienteEvent);

            return new ResponseView(medidaViewModel);
        }

        public async Task<ResponseView> AdicionarPlanoAlimentar(PacientePlanoAlimentarViewModel pacientePlanoAlimentarViewModel)
        {
            var command = new PacientePlanoAlimentarCommand(pacientePlanoAlimentarViewModel, pacienteRepository);
            if (!command.EhValido())
                return new ResponseView(command.ValidationResult);

            var paciente = await pacienteRepository.GetById(pacientePlanoAlimentarViewModel.PacienteId);
            var planoAlimentar = new PlanoAlimentarEntity()
            {
                Data = DateTime.UtcNow,
                Refeicoes = pacientePlanoAlimentarViewModel.Refeicoes.ToEntity().ToList()
            };

            await planoAlimentarRepository.AddAsync(planoAlimentar);

            if (paciente.PlanoAlimentares is null)
                paciente.PlanoAlimentares = new List<PlanoAlimentarEntity>();

            paciente.Update = true;
            paciente.PlanoAlimentares.Add(planoAlimentar);

            SendMessageService(paciente, true);
            pacienteRepository.Update(paciente.ToEntity());

            return new ResponseView(pacientePlanoAlimentarViewModel);
        }

        public ResponseView AtualizarPlanoAlimentar(PacienteAtualizarPlanoAlimentarViewModel pacienteAtualizarPlanoAlimentarViewModel)
        {
            var command = new PacienteAtualizarPlanoAlimentarCommand(pacienteAtualizarPlanoAlimentarViewModel, planoAlimentarRepository);
            if (!command.EhValido())
                return new ResponseView(command.ValidationResult);

            var planoAlimentar = pacienteAtualizarPlanoAlimentarViewModel.ToEntity();
            planoAlimentar.Id = pacienteAtualizarPlanoAlimentarViewModel.PlanoAlimentarId;
            planoAlimentarRepository.Update(planoAlimentar);

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