using Application.ViewModel.Pacientes;
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

        public static PacienteEntity ToEntity(this PacienteAtualizarViewModel pacienteViewModel)
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

        public static PacienteViewModel ToViewModel(this PacienteEvent paciente)
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

        public static IEnumerable<PacienteViewModel> ToListPacientesViewModel(this IEnumerable<PacienteEvent> pacientes)
        {
            return pacientes == null ? null : pacientes.Select(paciente => new PacienteViewModel
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

        public static IEnumerable<PacienteSimplificadoViewModel> ToListPacientesSimplificadoViewModelViewModel(this IEnumerable<PacienteEvent> pacientes)
        {
            return pacientes == null ? null : pacientes.Select(paciente => new PacienteSimplificadoViewModel
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                Sobrenome = paciente.Sobrenome,
                Email = paciente.Email,
                Telefone = paciente.Telefone
            });
        }

        public static PacienteEvent ToEvent(this PacienteEntity paciente)
        {
            return paciente == null ? null : new PacienteEvent()
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

        public static PacienteEvent ToPacienteEventUpdate(this PacienteAtualizarViewModel paciente)
        {
            var pacienteEvent = paciente
                                .ToEntity()
                                .ToEvent();
            pacienteEvent.Update = true;
            return pacienteEvent;
        }
    }
}