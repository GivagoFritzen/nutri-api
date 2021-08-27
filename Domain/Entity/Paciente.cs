﻿namespace Domain.Entity
{
    public class Paciente : Base
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public bool Sexo { get; set; }
        public float Peso { get; set; }
        public float Altura { get; set; }

        public Paciente()
        {
        }
    }
}