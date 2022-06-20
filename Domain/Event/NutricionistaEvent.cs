using System;
using System.Collections.Generic;

namespace Domain.Event
{
    public class NutricionistaEvent : GenericEvent
    {
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public bool Sexo { get; set; }
        public List<Guid> PacientesIds { get; set; }

        public NutricionistaEvent() { }

        public NutricionistaEvent(Guid id, bool delete) : base(id, "Nutricionista", delete) { }
    }
}
