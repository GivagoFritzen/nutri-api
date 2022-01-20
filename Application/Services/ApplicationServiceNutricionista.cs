using Application.Commands.Nutricionistas;
using Application.Interfaces;
using Application.Mapper;
using Application.ViewModel;
using Application.ViewModel.Nutricionistas;
using Core.Interfaces.Services;
using Domain.Event;
using Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApplicationServiceNutricionista : IApplicationServiceNutricionista
    {
        private readonly INutricionistaService nutricionistaService;
        private readonly IMessagingService messagingService;
        private readonly ISecurityService securityService;
        private readonly IUserService userService;

        public ApplicationServiceNutricionista(
            INutricionistaService nutricionistaService,
            IMessagingService messagingService,
            ISecurityService securityService,
            IUserService userService)
        {
            this.nutricionistaService = nutricionistaService;
            this.messagingService = messagingService;
            this.securityService = securityService;
            this.userService = userService;
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
            messagingService.Publish(new UserEvent(nutricionista.Id, nutricionista.Email));

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
            var nutricionista = await nutricionistaService.GetById(id);
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
            nutricionistaService.Update(nutricionistaViewModel.ToEntity());
            return new ResponseView(nutricionistaViewModel);
        }
    }
}