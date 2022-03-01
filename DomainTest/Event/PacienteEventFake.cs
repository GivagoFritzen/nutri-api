using Domain.Entity;
using Domain.Event;
using System;
using System.Collections.Generic;

namespace DomainTest.Event
{
    public static class PacienteEventFake
    {
        public static Guid Id = Guid.Parse("efa0f903-3275-4607-a376-22eb0d96fa0e");

        public static PacienteEvent GetPacienteEventFake()
        {
            return new PacienteEvent()
            {
                Id = Id,
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "teste@provedor.com",
                Cidade = "cidade",
                Telefone = "99999999",
                Sexo = true,
                Medidas = new List<MedidaEntity>()
            };
        }

        public static PacienteEvent GetPacienteEventUpdateFake(Guid id)
        {
            var @event = GetPacienteEventFake();
            @event.Id = id;
            @event.Update = true;
            return @event;
        }

        public static List<PacienteEvent> GetListPacienteEventFake()
        {
            return new List<PacienteEvent>
            {
                new PacienteEvent()
                {
                    Id = Id,
                    Nome = "nome",
                    Sobrenome = "sobrenome",
                    Email = "teste@provedor.com",
                    Cidade = "cidade",
                    Telefone = "99999999",
                    Sexo = true,
                    Medidas = new List<MedidaEntity>()
                }
            };
        }
    }
}
