using Application.ViewModel.Nutricionistas;
using DomainTest.Entity;

namespace ApplicationTest.ViewModel.Nutricionista
{
    public static class NutricionistaDesvincularOuVincularViewModelFake
    {
        public static NutricionistaDesvincularOuVincularViewModel GetFake()
        {
            return new NutricionistaDesvincularOuVincularViewModel()
            {
                Id = NutricionistaEntityFake.Id,
                PacienteEmail = "teste@provedor.com"
            };
        }

        public static NutricionistaDesvincularOuVincularViewModel GetFakeIdVazio()
        {
            return new NutricionistaDesvincularOuVincularViewModel()
            {
                PacienteEmail = "teste@provedor.com"
            };
        }
    }
}
