﻿using Application.Commands;
using Application.Validation.Pacientes;
using Application.ViewModel.Pacientes;
using Services;

namespace Application.Pacientes.Commands
{
    public class AdicionarPacienteCommand : Command
    {
        public PacienteAdicionarViewModel pacienteViewModel { get; private set; }
        private readonly IUserService userService;

        public AdicionarPacienteCommand(
            PacienteAdicionarViewModel pacienteViewModel,
            IUserService userService)
        {
            this.pacienteViewModel = pacienteViewModel;
            this.userService = userService;
        }

        public override bool EhValido()
        {
            ValidationResult = new PacienteAdicionarValidation(userService).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
