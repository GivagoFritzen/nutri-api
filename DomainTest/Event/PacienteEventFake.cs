﻿using Domain.Entity;
using Domain.Event;
using System;
using System.Collections.Generic;

namespace DomainTest.Event
{
    public static class PacienteEventFake
    {
        public static Guid Id = Guid.Parse("efa0f903-3275-4607-a376-22eb0d96fa0e");
        public static Guid MongoId = Guid.Parse("f24cb320-2aec-4116-bcee-4bc6841a84a9");

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

        public static IEnumerable<PacienteEvent> GetListPacienteEventFake(Guid? id = null)
        {
            return new List<PacienteEvent>
            {
                new PacienteEvent()
                {
                    Id = id is null ? Id : id.Value,
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
