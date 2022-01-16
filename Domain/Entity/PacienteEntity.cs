﻿namespace Domain.Entity
{
    public class PacienteEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public bool Sexo { get; set; }
        public MedidaEntity Medidas { get; set; }

        public PacienteEntity()
        {
        }
    }
}