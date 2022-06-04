using Domain.Event;
using DomainTest.Entity;
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
                Email = "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true,
                PacientesIds = new List<Guid>()
            };
        }

        public static NutricionistaEvent GetFakeNull()
        {
            NutricionistaEvent nutricionista = null;
            return nutricionista;
        }

        public static NutricionistaEvent GetFakePacientesNull()
        {
            var nutricionista = GetFake();
            nutricionista.PacientesIds = null;
            return nutricionista;
        }

        public static NutricionistaEvent GetFakeComPacientes()
        {
            var nutricionista = GetFake();
            nutricionista.PacientesIds = new List<Guid>()
            {
                PacienteEntityFake.Id
            };
            return nutricionista;
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
