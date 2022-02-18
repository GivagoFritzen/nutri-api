using Domain.Entity;
using System;

namespace Domain.Event
{
    public class PacienteEvent : UserEvent
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public bool Sexo { get; set; }
        public MedidaEntity Medida { get; set; }

        public PacienteEvent() { }

        public PacienteEvent(Guid id, bool delete) : base(id, delete) { }
    }
}
