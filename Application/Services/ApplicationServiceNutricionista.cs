using Application.Commands.Nutricionistas;
using Application.Interfaces;
using Application.Mapper;
using Application.ViewModel;
using Application.ViewModel.Nutricionistas;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApplicationServiceNutricionista : IApplicationServiceNutricionista
    {
        private readonly INutricionistaService nutricionistaService;
        private readonly ISecurityService securityService;

        public ApplicationServiceNutricionista(INutricionistaService nutricionistaService, ISecurityService securityService)
        {
            this.nutricionistaService = nutricionistaService;
            this.securityService = securityService;
        }

        public ResponseView Add(NutricionistaAdicionarViewModel nutricionistaViewModel)
        {
            var command = new NutricionistaAdicionarCommand(nutricionistaViewModel);
            if (!command.EhValido())
                return new ResponseView(command.ValidationResult);

            var nutricionista = nutricionistaViewModel.ToEntity();
            var passwordEncripted = securityService.EncryptPassword(nutricionista.Senha);
            nutricionista.Senha = passwordEncripted;
            nutricionistaService.Add(nutricionista);

            return new ResponseView(nutricionista.ToViewModel());
        }

        public async Task RemoveById(Guid id)
        {
            await nutricionistaService.RemoveById(id);
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
            var command = new NutricionistaAtualizarCommand(securityService, nutricionistaViewModel);
            if (!command.EhValido())
                return new ResponseView(command.ValidationResult);

            //Verificar e Add Senha
            nutricionistaService.Update(nutricionistaViewModel.ToEntity());
            return new ResponseView(nutricionistaViewModel);
        }
    }
}