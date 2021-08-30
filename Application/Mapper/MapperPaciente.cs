using Application.ViewModel;
using Application.Interfaces.Mapper;
using Domain.Entity;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Application.Mapper
{
    public class MapperPaciente : IMapperPaciente
    {
        public Paciente MapperViewModelToEntity(PacienteViewModel pacienteViewModel)
        {
            return pacienteViewModel == null ? null : new Paciente()
            {
                Id = Guid.NewGuid(),
                Nome = pacienteViewModel.Nome,
                Sobrenome = pacienteViewModel.Sobrenome,
                Email = pacienteViewModel.Email,
                Cidade = pacienteViewModel.Cidade,
                Telefone = pacienteViewModel.Telefone,
                Sexo = pacienteViewModel.Sexo,
                Peso = pacienteViewModel.Peso,
                Altura = pacienteViewModel.Altura
            };
        }

        public PacienteViewModel MapperEntityToViewModel(Paciente paciente)
        {
            return paciente == null ? null : new PacienteViewModel()
            {
                Nome = paciente.Nome,
                Sobrenome = paciente.Sobrenome,
                Email = paciente.Email,
                Cidade = paciente.Cidade,
                Telefone = paciente.Telefone,
                Sexo = paciente.Sexo,
                Peso = paciente.Peso,
                Altura = paciente.Altura,
            };
        }

        public IEnumerable<PacienteViewModel> MapperListPacientesViewModel(IEnumerable<Paciente> pacientes)
        {
            return pacientes.Select(paciente => new PacienteViewModel
            {
                Nome = paciente.Nome,
                Sobrenome = paciente.Sobrenome,
                Email = paciente.Email,
                Cidade = paciente.Cidade,
                Telefone = paciente.Telefone,
                Sexo = paciente.Sexo,
                Peso = paciente.Peso,
                Altura = paciente.Altura
            });
        }
    }
}