using Domain.Entity;
using System;
using System.Collections.Generic;

namespace Domain.Event
{
    public class PacienteEvent : UserEvent
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public bool Sexo { get; set; }
        public List<MedidaEntity> Medidas { get; set; }

        public PacienteEvent() { }

        public PacienteEvent(Guid id, bool delete) : base(id, delete) { }
    }
}
