using Domain.Event;
using System;
using System.Collections.Generic;

namespace DomainTest.Event
{
    public static class NutricionistaEventFake
    {
        public static NutricionistaEvent GetFake()
        {
            return new NutricionistaEvent()
            {
                Senha = "senha",
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "email",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true,
                PacientesIds = new List<Guid>()
            };
        }

        public static NutricionistaEvent GetUpdateFake()
        {
            var @event = GetFake();
            @event.Update = true;
            return @event;
        }

        public static List<NutricionistaEvent> GetListFake()
        {
            return new List<NutricionistaEvent>()
            {
                GetFake()
            };
        }
    }
}
