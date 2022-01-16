﻿using Application.ViewModel.Pacientes;
using Domain.Entity;
using Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Mapper
{
    public static class MapperPaciente
    {
        public static PacienteEntity ToEntity(this PacienteAdicionarViewModel pacienteViewModel)
        {
            return pacienteViewModel == null ? null : new PacienteEntity()
            {
                Id = Guid.NewGuid(),
                Nome = pacienteViewModel.Nome,
                Sobrenome = pacienteViewModel.Sobrenome,
                Email = pacienteViewModel.Email,
                Cidade = pacienteViewModel.Cidade,
                Telefone = pacienteViewModel.Telefone,
                Sexo = pacienteViewModel.Sexo,
                Medidas = pacienteViewModel.Medida.ToEntity()
            };
        }

        public static PacienteEntity ToEntity(this PacienteViewModel pacienteViewModel)
        {
            return pacienteViewModel == null ? null : new PacienteEntity()
            {
                Id = pacienteViewModel.Id,
                Nome = pacienteViewModel.Nome,
                Sobrenome = pacienteViewModel.Sobrenome,
                Email = pacienteViewModel.Email,
                Cidade = pacienteViewModel.Cidade,
                Telefone = pacienteViewModel.Telefone,
                Sexo = pacienteViewModel.Sexo,
                Medidas = pacienteViewModel.Medidas.ToEntity()
            };
        }

        public static PacienteViewModel ToViewModel(this PacienteEntity paciente)
        {
            return paciente == null ? null : new PacienteViewModel()
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                Sobrenome = paciente.Sobrenome,
                Email = paciente.Email,
                Cidade = paciente.Cidade,
                Telefone = paciente.Telefone,
                Sexo = paciente.Sexo,
                Medidas = paciente.Medidas.ToViewModel()
            };
        }

        public static IEnumerable<PacienteViewModel> ToListPacientesViewModel(this IEnumerable<PacienteEntity> pacientes)
        {
            return pacientes.Select(paciente => new PacienteViewModel
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                Sobrenome = paciente.Sobrenome,
                Email = paciente.Email,
                Cidade = paciente.Cidade,
                Telefone = paciente.Telefone,
                Sexo = paciente.Sexo,
                Medidas = paciente.Medidas.ToViewModel()
            });
        }

        public static PacienteEvent ToPacienteEvent(this PacienteEntity paciente)
        {
            return new PacienteEvent()
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                Sobrenome = paciente.Sobrenome,
                Email = paciente.Email,
                Cidade = paciente.Cidade,
                Telefone = paciente.Telefone,
                Sexo = paciente.Sexo,
                Medidas = paciente.Medidas
            };
        }

        public static PacienteEvent ToPacienteEventUpdate(this PacienteViewModel paciente)
        {
            var pacienteEvent = paciente
                                .ToEntity()
                                .ToPacienteEvent();
            pacienteEvent.Update = true;
            return pacienteEvent;
        }
    }
}