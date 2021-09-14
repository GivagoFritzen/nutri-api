using Application.ViewModel.Medidas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Pacientes
{
    public class PacienteViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public bool Sexo { get; set; }
        public MedidaViewModel Medidas { get; set; }
    }
}